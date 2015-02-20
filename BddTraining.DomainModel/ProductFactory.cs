using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddTraining.DomainModel
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
