using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;

namespace BddTraining.CmdHandlers.Interfaces
{
    public interface ICreateProductCmdHandler
    {
        Product Handle(CreateProductCmd command);
    }
}
