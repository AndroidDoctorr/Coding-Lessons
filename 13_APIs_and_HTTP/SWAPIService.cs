
using System.Net.Http;
class SWAPIService
{
    // In our SWAPIService, I'm going to add a new HttpClient field so that all of our methods can access it
    // We don't need it outside of our method, since our service should be the only thing interacting with the API
    private readonly HttpClient _httpClient = new HttpClient();

    // Let's first build a GetPerson method
    // To stick with the theme of the day, let's make it an async method as well
    public async Task<Person> GetPersonAsync(string url)
    {
        // Notice we don't have to call the .Result method since we can now use the await keyword
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        // Let's go ahead and be a little safe and check to see if our url worked
        if (response.IsSuccessStatusCode)
        {
            // We'll use our ReadAsAsync and get a Person object and then return it
            Person person = await response.Content.ReadAsAsync<Person>();
            return person;
        }

        // If it isn't a success, we'll just return null for now
        return null;
    }

    // We can now go use our method in the Program class

    // Writing a method to get Vehicles
    public async Task<Vehicle> GetVehicleAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<Vehicle>();
        }

        return null;
    }

    // Let's refactor our methods we have here and see what we can do with it
    // We want to be able to get any type with our method, let's use generics
    public async Task<T> GetAsync<T>(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            // We can pass the T type into our ReadAsAsync method here
            return await response.Content.ReadAsAsync<T>();
        }

        // Instead of null, since not ALL types can be null, we have to use the default keyword
        return default;
    }

    // Once we're done with the generic get, let's build a search method
    // Let's first check how our search method works. We can check the documentation or Postman
    // Go ahead and hit https://swapi.dev/api/people/?search=skywalker in Postman
    // Do we need a model for this response type as well? (yes)
    // Let's add a new model, I'll call it SearchResult

    // Now we can build our method that searches, we'll start with People first
    public async Task<SearchResult<Person>> GetPersonSearchAsync(string query)
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://swapi.dev/api/people/?search=" + query);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<SearchResult<Person>>();
        }

        return null;
    }

    // A generic method could look something like this
    public async Task<SearchResult<T>> GetSearchAsync<T>(string category, string query)
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://swapi.dev/api/" + category + "/?search=" + query);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<SearchResult<T>>();
        }

        return default;
    }

    // A method like this could help us make simpler methods like this as well
    public async Task<SearchResult<Vehicle>> GetVehicleSearchAsync(string query)
    {
        return await GetSearchAsync<Vehicle>("vehicles", query);
    }
}