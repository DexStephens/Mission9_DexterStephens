using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_DexterStephens.Infrastructure;
using Mission9_DexterStephens.Models;
using System.Linq;

namespace Mission9_DexterStephens.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public IBookstoreRepository BookstoreRepository { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public ShoppingCartModel(IBookstoreRepository bookstoreRepository)
        {
            BookstoreRepository = bookstoreRepository;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl) 
        {
            Books book = BookstoreRepository.Books.FirstOrDefault(x => x.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
