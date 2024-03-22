namespace Mission11_Hall.Models.ViewModels
{
    // Represents a view model for displaying a list of books with pagination information.
    public class BooksListViewModel
    {
        // IQueryable collection of books.
        public IQueryable<Book> Books { get; set; }

        // Pagination information associated with the book list.
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    }
}
