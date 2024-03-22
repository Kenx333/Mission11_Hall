namespace Mission11_Hall.Models.ViewModels
{
    // Represents pagination information used for paginating data.
    public class PaginationInfo
    {
        // Total number of items.
        public int TotalItems { get; set; }

        // Number of items displayed per page.
        public int ItemsPerPage { get; set; }

        // Current page number.
        public int CurrentPage { get; set; }

        // Calculates the total number of pages based on total items and items per page.
        public int TotalNumPages => (int)(Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}
