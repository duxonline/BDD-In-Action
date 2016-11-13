using System;

namespace BddTraining.DomainModel.Commands
{
    public class AddToCartCmd
    {
        public AddToCartCmd(Guid? cartId, Guid productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid? CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}