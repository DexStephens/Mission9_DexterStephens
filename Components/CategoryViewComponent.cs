using Microsoft.AspNetCore.Mvc;
using Mission9_DexterStephens.Models;
using System.Linq;

namespace Mission9_DexterStephens.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        public IBookstoreRepository BookstoreRepository { get; set; }

        public CategoryViewComponent(IBookstoreRepository bookstoreRepository)
        {
            BookstoreRepository = bookstoreRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = BookstoreRepository.Books.Select(x => x.Category).Distinct().OrderBy(x => x);

            return View(categories);
        }
    }
}
