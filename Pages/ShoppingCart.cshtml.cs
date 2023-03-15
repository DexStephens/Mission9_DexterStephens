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

        public ShoppingCartModel(IBookstoreRepository bookstoreRepository, Cart cart)
        {
            BookstoreRepository = bookstoreRepository;
            Cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long bookId, string returnUrl) 
        {
            Books book = BookstoreRepository.Books.FirstOrDefault(x => x.BookId == bookId);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {

            Cart.RemoveItem(Cart.CartItems.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage( new { ReturnUrl = returnUrl });
        }
    }
}
