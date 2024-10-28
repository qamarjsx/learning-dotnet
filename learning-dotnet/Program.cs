using learning_dotnet.Models;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Book> books = new List<Book>();

List<Book> getBooks() {
    return books;
}


Book? getBook(int id) {
    Book? foundBook = books.Find(book => book.Id == id);

    if (foundBook == null) {
        return null;
    }

    return foundBook;
}

Book? addBook(Book book) {
    if(string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author) || book.PublishYear > DateTime.Now.Year) {
        return (Book?)Results.BadRequest("All fields are required and must be valid.");
    }
    books.Add(book);
    return book;
}

List<Book> deleteBook(int id) {
    Book? foundBook = getBook(id);
    if (foundBook == null) {
        return books;
    }
    books.Remove(foundBook);
    return books;
}

// Get all books
app.MapGet("/api/books", () => getBooks());

// Get one book 
app.MapGet("/api/books/{id}", (int id) => getBook(id));

// Add a new book
app.MapPost("/api/books", (Book book) => addBook(book));

// Delete a book
app.MapDelete("/api/books/{id}", (int id) => deleteBook(id));

app.Run();
