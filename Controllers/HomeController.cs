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

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var booksVM = new BooksViewModel(
                bookstoreRepository.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                new PageInfo(bookstoreRepository.Books.Count(), pageSize, pageNum)
                );

            return View(booksVM);
        }
    }
}
