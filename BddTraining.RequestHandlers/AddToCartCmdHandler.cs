using System;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.RepositoryInterfaces;
using BddTraining.RequestHandlers.Interfaces;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.RequestHandlers
{
    public class AddToCartCmdHandler: IAddToCartCmdHandler
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
            var shoppingCart = GetCart(command); // Todo: refactor the code

            var product = _productRepository.Get(command.ProductId);

            shoppingCart.AddItem(product, command.Quantity);

            _cartRepository.SaveOrUpdate(shoppingCart);

            SessionManager.CommitTrans();

            return shoppingCart;
        }

        private ShoppingCart GetCart(AddToCartCmd command)
        {
            var cartExists = command.CartId != null;

            if (cartExists)
            {
                var shoppingCart = _cartRepository.Get(command.CartId.Value);

                if (shoppingCart != null)
                    return shoppingCart;

                throw new Exception(string.Format("Shopping cart ID ({0}) is not valid.", command.CartId));
            }

            return new ShoppingCart();
        }
    }
}
