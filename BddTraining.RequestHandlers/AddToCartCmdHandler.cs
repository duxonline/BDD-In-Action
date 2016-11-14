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
        private readonly IShoppingCartRetriever _cartRetriever;

        public AddToCartCmdHandler(IShoppingCartRepository cartRepository, IProductRepository productRepository, IShoppingCartRetriever cartRetriever)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _cartRetriever = cartRetriever;
        }

        public ShoppingCart Handle(AddToCartCmd command)
        {
            var shoppingCart = _cartRetriever.Get(command.CartId);

            var product = _productRepository.Get(command.ProductId);

            shoppingCart.AddItem(product, command.Quantity);

            _cartRepository.SaveOrUpdate(shoppingCart);

            SessionManager.CommitTrans();

            return shoppingCart;
        }
    }
}
