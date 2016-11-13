using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;

namespace BddTraining.CmdHandlers.Interfaces
{
    public interface IAddToCartCmdHandler
    {
        ShoppingCart Handle(AddToCartCmd command);
    }
}
