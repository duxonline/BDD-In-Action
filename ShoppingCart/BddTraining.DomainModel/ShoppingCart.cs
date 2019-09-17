using System.Collections.Generic;
using System.Linq;
using BddTraining.SharpArch.Domain;

namespace BddTraining.DomainModel
{
    public class ShoppingCart : Entity
    {
        private readonly IList<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();

        public ShoppingCart()
        {
        }

        public virtual IEnumerable<ShoppingCartItem> CartItems { get { return cartItems; } }

        public virtual decimal SubTotal
        {
            get { return cartItems.Sum(ci => ci.SubTotal); }
        }

        public virtual decimal TaxTotal
        {
            get { return cartItems.Sum(ci => ci.Tax); }
        }

        public virtual decimal GrandTotal
        {
            get { return SubTotal + TaxTotal; }
        }

        public virtual void Add(Product product, int quantity)
        {
            var itemFound = cartItems.Where(x => x.ProductID.Equals(product.ID)).FirstOrDefault();

            if (itemFound == null)
            {
                var newItem = new ShoppingCartItem(this, product, quantity);
                cartItems.Add(newItem);
            }
            else
            {
                itemFound.Update(product, quantity);
            }
        }
    }
}