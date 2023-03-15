using Microsoft.AspNetCore.Mvc;
using Mission9_DexterStephens.Models;

namespace Mission9_DexterStephens.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository _checkoutRepository;
        public Cart Cart { get; set; }

        public CheckoutController(ICheckoutRepository newRepository, Cart cart)
        {
            _checkoutRepository = newRepository;
            Cart = cart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }
        [HttpPost]
        public IActionResult Checkout(Checkout checkoutItem)
        {
            if(Cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                checkoutItem.Items = Cart.CartItems.ToArray();
                _checkoutRepository.SaveCheckout(checkoutItem);
                Cart.ClearCart();

                return RedirectToPage("/CheckoutConfirm");
            }
            else
            {
                return View();
            }
        }
    }
}
