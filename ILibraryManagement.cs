public interface ILibraryManagement
{
    void AddBook(Book book);
    void RemoveBook(string bookId);
    string GetBookDetails(string bookId);
    void RegisterMember(Member member);
    void RemoveMember(string memberId);
    string GetMemberDetails(string memberId);
    void BorrowBook(string memberId, string bookId);
    void ReturnBook(string memberId, string bookId);
}