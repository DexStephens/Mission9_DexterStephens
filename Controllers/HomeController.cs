using Microsoft.AspNetCore.Mvc;
using Mission9_DexterStephens.Models;
using Mission9_DexterStephens.Models.ViewModels;
using System.Linq;

namespace Mission9_DexterStephens.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository bookstoreRepository;

        public HomeController(IBookstoreRepository newRepository)
        {
            bookstoreRepository = newRepository;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var booksVM = new BooksViewModel(
                bookstoreRepository.Books
                .Where(x => x.Category == bookCategory || bookCategory == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                new PageInfo(
                    bookCategory == null ? bookstoreRepository.Books.Count() : bookstoreRepository.Books.Where(x => x.Category == bookCategory).Count(), 
                    pageSize, 
                    pageNum)
                );

            return View(booksVM);
        }
    }
}
