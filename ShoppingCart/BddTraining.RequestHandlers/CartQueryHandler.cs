using System;
using BddTraining.DomainModel;
using BddTraining.DomainModel.RepositoryInterfaces;
using BddTraining.RequestHandlers.Interfaces;

namespace BddTraining.RequestHandlers
{
    public class CartQueryHandler: ICartQueryHandler
    {
        private readonly IShoppingCartRepository _cartRepository;

        public CartQueryHandler(IShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public ShoppingCart GetCartDetails(Guid cartId)
        {
            var shoppingCart = _cartRepository.Get(cartId);
            return shoppingCart;
        }
    }
}
