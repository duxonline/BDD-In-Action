using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;

namespace BddTraining.RequestHandlers.Interfaces
{
    public interface ICreateProductCmdHandler
    {
        Product Handle(CreateProductCmd command);
    }
}
