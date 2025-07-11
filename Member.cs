

using System.Transactions;

namespace Library_Management_System;

public class Member
{
    private string _name;
    private string _id;
    
    private LibraryTransaction _transaction;
    public LibraryTransaction Transaction => _transaction;
    
    private Book _book;      
    public Book Book => _book; 
    
    private List<Book> _borrowedBooks = new();
    private List<LibraryTransaction> _transactions = new();

    public string Name
    {
        get => _name;
        private set => _name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Name cannot be empty") : value.Trim();
    }
    public string Id
    {
        get => _id;
        private set => _id = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Id cannot be empty") : value.Trim();
    }

    public Member(string name, string id)
    {
        Name = name;
        Id = id;
    }
  
    public bool BorrowBook(Book book)
    {
        if (!book.IsAvailable) return false;

        if (book.Borrow())
        {
            _borrowedBooks.Add(book);
        
            // Create transaction record
            var transaction = new LibraryTransaction(
                Guid.NewGuid().ToString(), 
                book, 
                this, 
                TransactionType.Borrow
            );
            _transactions.Add(transaction);
        
            return true;
        }
        return false;
    }

    public bool ReturnBook(Book book)
    {
        if (!_borrowedBooks.Contains(book))
            return false;

        book.Return();
        _borrowedBooks.Remove(book);
        return true;
    }

    public List<LibraryTransaction> GetTransactionHistory()
    {
        return _transactions;
    }
}