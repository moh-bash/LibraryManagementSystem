public class Member : Person
{
    public string Id { get; set; }

    public Member(string id, string name, string email) : base(name, email)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"Member: {Name}, Email: {Email}, ID: {Id}";
    }
}
