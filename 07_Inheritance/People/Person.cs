public class Person
{
    private string _firstName = "";
    private string _lastName = "";

    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string Name
    {
        get
        {
            string fullName = $"{_firstName} {_lastName}";

            return (string.IsNullOrWhiteSpace(fullName)) ? "Unnamed" : fullName;
        }
    }

    public Person() { }

    public Person(string firstName, string lastName, string phoneNumber, string email)
    {
        _firstName = firstName;
        _lastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public void SetFirstName(string name)
    {
        _firstName = name;
    }

    public void SetLastName(string name)
    {
        _lastName = name;
    }
}