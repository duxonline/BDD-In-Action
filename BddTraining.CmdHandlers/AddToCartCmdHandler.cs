using System;
using BddTraining.DomainModel;
using BddTraining.DomainModel.RepositoryInterfaces;

namespace BddTraining.CmdHandlers
{
    public class AddToCartCmdHandler
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartCmdHandler(IShoppingCartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public ShoppingCart Handle(AddToCartCmd command)
        {
            var shoppingCart = GetCart(command);

            var product = _productRepository.Get(command.ProductID);

            shoppingCart.AddItem(product, command.Quantity);

            _cartRepository.SaveOrUpdate(shoppingCart);

            return shoppingCart;
        }

        private ShoppingCart GetCart(AddToCartCmd command)
        {
            bool cartExists = command.CartID != Guid.Empty;

            if (cartExists)
            {
                var shoppingCart = _cartRepository.Get(command.CartID);
                if (shoppingCart != null)
                    return shoppingCart;

                throw new Exception(string.Format("Shopping cart ID ({0}) is not valid.", command.CartID));
            }

            return new ShoppingCart();
        }
    }
}
