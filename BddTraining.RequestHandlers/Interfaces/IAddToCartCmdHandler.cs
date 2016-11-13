using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;

namespace BddTraining.RequestHandlers.Interfaces
{
    public interface IAddToCartCmdHandler
    {
        ShoppingCart Handle(AddToCartCmd command);
    }
}
