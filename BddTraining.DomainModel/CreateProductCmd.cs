namespace BddTraining.DomainModel
{
    public class CreateProductCmd
    {
        // Note: should be used by SpecFlow only and so are setters
        public CreateProductCmd() { }

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
