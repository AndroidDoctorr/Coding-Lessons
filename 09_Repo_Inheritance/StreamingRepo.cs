public class StreamingRepo : StreamingContentRepository
{
    public Movie GetMovieByTitle(string title)
    {
        foreach (StreamingContent content in _contentDirectory)
        {
            if (content is Movie && content.Title.ToLower() == title.ToLower())
            {
                return (Movie)content;
            }
        }

        return default;

        return (Movie)_contentDirectory.FirstOrDefault(c => c is Movie && c.Title.ToLower() == title.ToLower());
    }

    public List<Show> GetAllShows()
    {
        List<Show> allShows = new List<Show>();
        foreach (StreamingContent content in _contentDirectory)
        {
            if (content is Show)
            {
                allShows.Add((Show)content);
            }
        }
        return allShows;

        // LINQ
        List<Show> allShowsLinq = _contentDirectory
            .Where(c => c is Show)
            .Select(c => (Show)c)
            .ToList();


        List<int> intList = new List<int>() { 1, 2, 3 };
        List<int> incrementedList = intList.Select(x => x + 3).ToList();
        // { 4, 5, 6 }
    }
}