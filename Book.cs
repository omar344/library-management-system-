namespace Library_Management_System;
public class Book
{
    private string _title;
    private string _author;
    private string _ISBN;
    private int _quantity;

    public bool IsAvailable => _quantity > 0;
    
    public string Title 
    { 
        get => _title; 
        private set => _title = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Title cannot be empty") : value.Trim();
    }
    public string Author 
    { 
        get => _author; 
        private set => _author = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Auther cannot be empty") : value.Trim();
    }
    public string ISBN 
    { 
        get => _ISBN; 
        private set => _ISBN = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("ISBN cannot be empty") : value.Trim();
    }

    public Book(string title, string author, string ISBN, int quantity)
    {
        Title = title;
        Author = author;
        ISBN = ISBN;
        _quantity = quantity;
    }
    public bool Borrow()
    {
        if (_quantity <= 0)
            return false;

        _quantity--;
        return true;
    }

    public void Return()
    {
        _quantity++;
    }
    
    
    

}