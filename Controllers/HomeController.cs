using Microsoft.AspNetCore.Mvc;
using Mission11_Hall.Models;
using Mission11_Hall.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Hall.Controllers
{
    public class HomeController : Controller
    {
        private IBooksRepository _repo;
        public HomeController(IBooksRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var blah = new BooksListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(blah);
        }
    }
}
