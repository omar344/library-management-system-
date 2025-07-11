using Library_Management_System;

class Program
{
    static void Main(string[] args)
    {
        var library = new LibraryManger();

        var book = new Book("Clean Code", "Robert Martin", "ISBN123", 4);
        library.AddBook(book);
        Console.WriteLine("Book added: Clean Code");

        var member = new Member("Omar", "M001");
        library.RegisterMember(member);
        Console.WriteLine("Member registered: Omar");

        bool borrowResult = library.BorrowBook(member, book);
        Console.WriteLine(borrowResult 
            ? "Borrowed 'Clean Code' successfully." 
            : "Borrow failed.");

        
        bool returnResult = library.ReturnBook(member, book);
        Console.WriteLine(returnResult 
            ? "Returned 'Clean Code' successfully." 
            : "Return failed.");
        // 6. Print all transactions
        Console.WriteLine("\nTransaction History:");
        foreach (var txn in member.GetTransactionHistory())
        {
            Console.WriteLine($"[{txn.TransactionDate}] {txn.Action} - {txn.Book.Title} by {txn.Member.Name} (Txn ID: {txn.TransactionId})");
        }
    }
}