using System;

class Program
{
    static void Main(string[] args)
    {
        LibraryManagementSystem lms = new LibraryManagementSystem();

        // إضافة كتب وأعضاء افتراضيين بدون رسائل
        lms.AddBook(new Book("1", "The Great Gatsby", "F. Scott Fitzgerald", "1234567890123"), true);
        lms.AddBook(new Book("2", "1984", "George Orwell", "9876543210123"), true);
        lms.AddBook(new Book("3", "To Kill a Mockingbird", "Harper Lee", "4567891230123"), true);
        lms.AddBook(new Book("4", "To Kill  Mockingbird", "Harper Lee", "1566121321515"), true);


        lms.RegisterMember(new Member("1", "Ali", "ali@example.com"), true);
        lms.RegisterMember(new Member("2", "Sara", "sara@example.com"), true);
        lms.RegisterMember(new Member("3", "Omar", "omar@example.com"), true);

        // الاشتراك في الأحداث
        lms.OnBookBorrowed += msg => Console.WriteLine("[Event] " + msg);
        lms.OnBookReturned += msg => Console.WriteLine("[Event] " + msg);

        while (true)
        {
            Console.WriteLine("\n==== Library Management System ====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Register Member");
            Console.WriteLine("4. Remove Member");
            Console.WriteLine("5. Borrow Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. View Book Details");
            Console.WriteLine("8. View Member Details");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Book ID: ");
                    string bid = Console.ReadLine();
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();
                    lms.AddBook(new Book(bid, title, author, isbn));
                    break;

                case "2":
                    Console.Write("Enter Book ID: ");
                    lms.RemoveBook(Console.ReadLine());
                    break;

                case "3":
                    Console.Write("Enter Member ID: ");
                    string mid = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    lms.RegisterMember(new Member(mid, name, email));
                    break;

                case "4":
                    Console.Write("Enter Member ID: ");
                    lms.RemoveMember(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Enter Member ID: ");
                    string m1 = Console.ReadLine();
                    Console.Write("Enter Book ID: ");
                    string b1 = Console.ReadLine();
                    lms.BorrowBook(m1, b1);
                    break;

                case "6":
                    Console.Write("Enter Member ID: ");
                    string m2 = Console.ReadLine();
                    Console.Write("Enter Book ID: ");
                    string b2 = Console.ReadLine();
                    lms.ReturnBook(m2, b2);
                    break;

                case "7":
                    Console.Write("Enter Book ID: ");
                    Console.WriteLine(lms.GetBookDetails(Console.ReadLine()));
                    break;

                case "8":
                    Console.Write("Enter Member ID: ");
                    Console.WriteLine(lms.GetMemberDetails(Console.ReadLine()));
                    break;

                case "9":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
