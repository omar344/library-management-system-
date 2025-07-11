namespace Library_Management_System;

public class LibraryManger
{
    private List<Book> _books = new();
    private List<Member> _members = new();
    private List<LibraryTransaction> _transactions = new();
    private int _transactionCounter = 0;

    private string GenerateTransactionId()
    {
        _transactionCounter++;
        return $"TXN-{DateTime.Now:yyyyMMdd}-{_transactionCounter:D6}";
    }
    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void RegisterMember(Member member)
    {
        _members.Add(member);
    }
    public bool BorrowBook(Member member, Book book)
    {
        if (member == null || book == null) return false;
        if (!book.IsAvailable) return false;

        bool borrowed = member.BorrowBook(book);
        if (borrowed)
        {
            string txnId = GenerateTransactionId();
            var transaction = new LibraryTransaction(txnId, book, member, TransactionType.Borrow);
            _transactions.Add(transaction);
            return true;
        }

        return false;
    }
    public bool ReturnBook(Member member, Book book)
    {
        // Your logic here:
        // 1. Check if member actually borrowed this book
        // 2. Update book quantity
        // 3. Update member's borrowed books
        // 4. Create transaction record
        // 5. Return success/failure
        if (member == null || book == null) return false;
        bool returned = member.ReturnBook(book);
        if (returned)
        {
            string txnId = GenerateTransactionId();
            var transaction = new LibraryTransaction(txnId, book, member, TransactionType.Return);
            _transactions.Add(transaction);
            return true;
        }
        return false;
    }
    
}