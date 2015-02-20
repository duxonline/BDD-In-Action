using System.Collections.Generic;
using System.Linq;
using RosterLive.SharpArch.Domain;

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

        public virtual void AddItem(Product product, int quantity)
        {
            var found = false;

            foreach (var cartItem in CartItems)
            {
                if (cartItem.ProductID.Equals(product.ID))
                {
                    cartItem.Add(product, quantity);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                var cartItem = new ShoppingCartItem(this, product, quantity);
                cartItems.Add(cartItem);
            }
        }
    }
}