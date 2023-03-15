using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission9_DexterStephens.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }
        [BindNever]
        public ICollection<CartItem> Items { get; set; }
        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first address line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter a ZIP")]
        public string Zip { get; set; }
    }
}
