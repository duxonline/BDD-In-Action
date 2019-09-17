using BddTraining.DomainModel.Commands;

namespace BddTraining.DomainModel.Factories
{
    public class ProductFactory
    {
        public static Product Create(CreateProductCmd command)
        {
            var product = new Product
            {
                Name = command.Name,
                Price = command.Price,
                IsImported = command.IsImported,
                Type = command.Type
            };

            return product;
        }
    }
}
