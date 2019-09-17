using System;
using BddTraining.DomainModel;
using BddTraining.DomainModel.RepositoryInterfaces;
using BddTraining.RequestHandlers.Interfaces;

namespace BddTraining.RequestHandlers
{
    public class ShoppingCartRetriever: IShoppingCartRetriever
    {
        private readonly IShoppingCartRepository _cartRepository;

        public ShoppingCartRetriever(IShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public ShoppingCart TryGet(Guid? cartId)
        {
            var cartExists = cartId != null;

            if (cartExists)
            {
                var shoppingCart = _cartRepository.Get(cartId.Value);

                if (shoppingCart != null)
                    return shoppingCart;

                throw new Exception(string.Format("Shopping cart Id ({0}) is not valid.", cartId));
            }

            return new ShoppingCart();
        }
    }
}
