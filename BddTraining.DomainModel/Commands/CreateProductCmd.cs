namespace BddTraining.DomainModel.Commands
{
    public class CreateProductCmd
    {
        public CreateProductCmd()
        {            
        }

        public CreateProductCmd(string name, decimal price, bool isImported, ProductType type)
        {
            Name = name;
            Price = price;
            IsImported = isImported;
            Type = type;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
        public ProductType Type { get; set; }
    }
}
