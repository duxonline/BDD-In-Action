using BddTraining.CmdHandlers;
using BddTraining.Common;
using BddTraining.DomainModel;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.Features.Steps.Utility
{
    public class CartBuilder
    {
        public static ShoppingCart Build(AddToCartCmd command)
        {
            var cmdHandler = DependencyResolver.Resolve<AddToCartCmdHandler>();

            var shoppingCart = cmdHandler.Handle(command);
            SessionManager.CommitTrans();

            return shoppingCart;
        }
    }
}
