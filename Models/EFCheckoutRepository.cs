using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mission9_DexterStephens.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext _context;
        public IQueryable<Checkout> Checkouts => _context.Checkouts.Include(x => x.Items).ThenInclude(x => x.Book);
        public EFCheckoutRepository(BookstoreContext bookstoreContext)
        {
            _context = bookstoreContext;
        }
        public void SaveCheckout(Checkout checkoutItem)
        {
            _context.AttachRange(checkoutItem.Items.Select(x => x.Book));
            if(checkoutItem.CheckoutId == 0)
            {
                _context.Checkouts.Add(checkoutItem);
            }

            _context.SaveChanges();
        }
    }
}
