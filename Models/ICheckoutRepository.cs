using System.Linq;

namespace Mission9_DexterStephens.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkouts { get; }
        void SaveCheckout(Checkout checkoutItem);
    }
}
