using BookLibraryAPI.Models;
using BookLibraryAPI.ViewModels;

namespace BookLibraryAPI.Interfaces
{
    public interface IBooksService
    {
        void AddBook(BookVM bookVM);

        void DeleteBookById(int bookId);

        List<Book> GetAllBooks();

        Book? GetBookById(int bookId);

        Book? UpdateBookById(int bookId, BookVM bookVM);
    }
}