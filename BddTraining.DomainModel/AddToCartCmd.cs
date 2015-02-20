using System;

namespace BddTraining.DomainModel
{
    public class AddToCartCmd
    {
        public AddToCartCmd(Guid cartID, Guid productID, int quantity)
        {
            CartID = cartID;
            ProductID = productID;
            Quantity = quantity;
        }

        public Guid CartID { get; private set; }
        public Guid ProductID { get; private set; }
        public int Quantity { get; private set; }
    }
}