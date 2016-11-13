using System.Collections.Generic;
using System.Linq;
using BddTraining.CmdHandlers;
using BddTraining.Common;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.RequestHandlers;

namespace BddTraining.Features.Steps.Utility
{
    public class ProductBuilder
    {
        public static Product Build(CreateProductCmd command)
        {
            var createProductCmdHandler = DependencyResolver.Resolve<CreateProductCmdHandler>();

            var product = createProductCmdHandler.Handle(command);

            return product;
        }

        public static IList<Product> Build(IEnumerable<CreateProductCmd> commands)
        {
            return commands.Select(Build).ToList();
        }
    }
}
