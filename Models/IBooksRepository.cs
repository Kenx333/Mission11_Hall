namespace Mission11_Hall.Models
{
    // Interface defining operations for accessing books.
    public interface IBooksRepository
    {
        // Gets a queryable collection of books.
        public IQueryable<Book> Books { get; }
    }
}
