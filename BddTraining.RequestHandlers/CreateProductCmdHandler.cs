using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using BddTraining.DomainModel.RepositoryInterfaces;
using BddTraining.RequestHandlers.Interfaces;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.RequestHandlers
{
    public class CreateProductCmdHandler : ICreateProductCmdHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCmdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Handle(CreateProductCmd command)
        {
            var product = ProductFactory.Create(command);

            _productRepository.SaveOrUpdate(product);

            SessionManager.CommitTrans();

            return product;
        }
    }
}
