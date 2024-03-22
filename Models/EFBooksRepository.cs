using SQLitePCL;

namespace Mission11_Hall.Models
{
    // Represents a repository for accessing books using Entity Framework.
    public class EFBooksRepository : IBooksRepository
    {
        private BookstoreContext _context;

        // Constructor for EFBooksRepository.
        // It initializes the context used for accessing books.
        public EFBooksRepository(BookstoreContext temp)
        {
            _context = temp;
        }

        // Gets a queryable collection of books from the context.
        public IQueryable<Book> Books => _context.Books;
    }
}
