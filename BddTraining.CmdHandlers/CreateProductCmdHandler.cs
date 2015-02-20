using BddTraining.DomainModel;
using BddTraining.DomainModel.RepositoryInterfaces;

namespace BddTraining.CmdHandlers
{
    public class CreateProductCmdHandler
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

            return product;
        }
    }
}
