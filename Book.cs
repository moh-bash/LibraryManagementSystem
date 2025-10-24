public class Book
{
    public string Id { get; }
    public string Title { get; }
    public string Author { get; }
    public string ISBN { get; }
    public bool IsAvailable { get; set; }

    public Book(string id, string title, string author, string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }

    public override string ToString()
    {
        return $"Book: {Title}, Author: {Author}, ISBN: {ISBN}, Available: {IsAvailable}";
    }
}