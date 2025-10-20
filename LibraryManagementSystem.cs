using System;
using System.Collections.Generic;

public class LibraryManagementSystem : ILibraryManagement
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    private NotificationService notifier = new NotificationService(); // Delegation

    // 🔔 Events
    public event Action<string>? OnBookBorrowed;
    public event Action<string>? OnBookReturned;

    // ------------------------
    // النسخة مع silent (خاصة للإضافات الافتراضية)
    public void AddBook(Book book, bool silent = false)
    {
        books.Add(book);
        if (!silent)
            Console.WriteLine($"Book '{book.Title}' added.");
    }

    public void RegisterMember(Member member, bool silent = false)
    {
        members.Add(member);
        if (!silent)
            Console.WriteLine($"Member '{member.Name}' registered.");
    }

    // ------------------------
    // دوال مطابقة للواجهة (تستدعي النسخة مع silent=false)
    public void AddBook(Book book)
    {
        AddBook(book, false);
    }

    public void RegisterMember(Member member)
    {
        RegisterMember(member, false);
    }

    // إزالة كتاب
    public void RemoveBook(string bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }
        books.Remove(book);
        Console.WriteLine($"Book '{book.Title}' removed.");
    }

    // عرض تفاصيل كتاب
    public string GetBookDetails(string bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        return book?.ToString() ?? "Book not found.";
    }

    // إزالة عضو
    public void RemoveMember(string memberId)
    {
        var member = members.Find(m => m.Id == memberId);
        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }
        members.Remove(member);
        Console.WriteLine($"Member '{member.Name}' removed.");
    }

    // عرض تفاصيل عضو
    public string GetMemberDetails(string memberId)
    {
        var member = members.Find(m => m.Id == memberId);
        return member?.ToString() ?? "Member not found.";
    }

    // استعارة كتاب
    public void BorrowBook(string memberId, string bookId)
    {
        var member = members.Find(m => m.Id == memberId);
        var book = books.Find(b => b.Id == bookId);

        if (member == null || book == null || !book.IsAvailable)
        {
            Console.WriteLine("Cannot borrow book.");
            return;
        }

        book.IsAvailable = false;
        Console.WriteLine($"'{member.Name}' borrowed '{book.Title}'.");
        notifier.Notify($"{member.Name} borrowed {book.Title}");
        OnBookBorrowed?.Invoke($"{member.Name} borrowed {book.Title}");
    }

    // إرجاع كتاب
    public void ReturnBook(string memberId, string bookId)
    {
        var member = members.Find(m => m.Id == memberId);
        var book = books.Find(b => b.Id == bookId);

        if (member == null || book == null || book.IsAvailable)
        {
            Console.WriteLine("Cannot return book.");
            return;
        }

        book.IsAvailable = true;
        Console.WriteLine($"'{member.Name}' returned '{book.Title}'.");
        notifier.Notify($"{member.Name} returned {book.Title}");
        OnBookReturned?.Invoke($"{member.Name} returned {book.Title}");
    }
}
