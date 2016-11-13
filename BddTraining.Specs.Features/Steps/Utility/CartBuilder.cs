using BddTraining.Common;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.RequestHandlers;

namespace BddTraining.Features.Steps.Utility
{
    public class CartBuilder
    {
        public static ShoppingCart Build(AddToCartCmd command)
        {
            var cmdHandler = DependencyResolver.Resolve<AddToCartCmdHandler>();

            var shoppingCart = cmdHandler.Handle(command);

            return shoppingCart;
        }
    }
}
