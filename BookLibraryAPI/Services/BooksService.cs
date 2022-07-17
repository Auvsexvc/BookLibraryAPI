using BookLibraryAPI.Data;
using BookLibraryAPI.Interfaces;
using BookLibraryAPI.Models;
using BookLibraryAPI.ViewModels;

namespace BookLibraryAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly AppDbContext _dbContext;

        public BooksService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBook(BookVM bookVM)
        {
            var book = new Book()
            {
                Title = bookVM.Title,
                Description = bookVM.Description,
                IsRead = bookVM.IsRead,
                DateRead = bookVM.DateRead,
                Rate = bookVM.Rate,
                Genre = bookVM.Genre,
                Author = bookVM.Author,
                Cover = bookVM.Cover,
                DateAdded = DateTime.Now
            };

            _dbContext.Add(book);
            _dbContext.SaveChanges();
        }

        public List<Book> GetAllBooks() => _dbContext.Books.ToList();

        public Book? GetBookById(int bookId) => _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

        public Book? UpdateBookById(int bookId, BookVM bookVM)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                book.Title = bookVM.Title;
                book.Description = bookVM.Description;
                book.IsRead = bookVM.IsRead;
                book.DateRead = bookVM.DateRead;
                book.Rate = bookVM.Rate;
                book.Genre = bookVM.Genre;
                book.Author = bookVM.Author;
                book.Cover = bookVM.Cover;

                _dbContext.SaveChanges();
            }

            return book;
        }

        public void DeleteBookById(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
    }
}