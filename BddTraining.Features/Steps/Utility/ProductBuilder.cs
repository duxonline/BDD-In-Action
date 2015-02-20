using System.Collections.Generic;
using System.Linq;
using BddTraining.CmdHandlers;
using BddTraining.Common;
using BddTraining.DomainModel;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.Features.Steps.Utility
{
    public class ProductBuilder
    {
        public static Product Build(CreateProductCmd command)
        {
            var cmdHandler = DependencyResolver.Resolve<CreateProductCmdHandler>();

            var product = cmdHandler.Handle(command);
            SessionManager.CommitTrans();

            return product;
        }

        public static IList<Product> Build(IEnumerable<CreateProductCmd> commands)
        {
            return commands.Select(Build).ToList();
        }
    }
}
