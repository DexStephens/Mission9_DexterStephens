using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Mission9_DexterStephens.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual void AddItem(Books book, int quantity)
        {
            CartItem cartItem = CartItems.Where(x => x.Book.BookId== book.BookId).FirstOrDefault();
            if (cartItem == null)
            {
                CartItems.Add( new CartItem { Book = book, Quantity = quantity } );
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Books book)
        {
            CartItems.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            CartItems.Clear();
        }

        public double CalculateTotal()
        {
            double sum = CartItems.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class CartItem
    {
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }

}
