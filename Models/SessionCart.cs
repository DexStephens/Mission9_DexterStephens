using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission9_DexterStephens.Infrastructure;
using System;
using System.Text.Json.Serialization;

namespace Mission9_DexterStephens.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

            cart.Session= session;

            return cart;
        }

        public override void AddItem(Books book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("cart", this);
        }

        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("cart");
        }

    }
}
