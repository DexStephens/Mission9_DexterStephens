using Microsoft.AspNetCore.Mvc;
using Mission9_DexterStephens.Models;

namespace Mission9_DexterStephens.Components
{
    public class CartViewComponent : ViewComponent
    {
        public Cart Cart { get; set; }

        public CartViewComponent(Cart cart)
        {
            Cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}
