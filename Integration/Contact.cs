public class Contact
{
    public string Name { get; }
    public string LastName { get; }
    public long PhoneNumber { get; }
    public string Email { get; }
    public Contact(string name, string lastName, long phoneNumber, string email)
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    public override string ToString()
    {
        return $"{Name} {LastName}\n\n{PhoneNumber} {Email}";
    }
}