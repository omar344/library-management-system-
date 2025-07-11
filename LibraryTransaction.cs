using System.Data;

namespace Library_Management_System;

public class LibraryTransaction
{
    public string TransactionId { get; }
    public TransactionType Action { get; }
    public DateTime TransactionDate { get; }
    public Member Member { get; }
    public Book Book { get; }

    public LibraryTransaction(string transactionId, Book book, Member member, TransactionType action)
    {
        TransactionId = transactionId;
        Book = book;
        Member = member;
        Action = action;
        TransactionDate = DateTime.Now;
    }
}