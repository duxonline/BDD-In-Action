using System;
using BddTraining.SharpArch.Domain;

namespace BddTraining.DomainModel
{
    public class ShoppingCartItem : Entity
    {
        public ShoppingCartItem() { }

        public ShoppingCartItem(ShoppingCart shoppingCart, Product product, int quantity)
        {
            ProductID = product.ID;
            Name = product.Name;
            Price = product.Price;

            ShoppingCart = shoppingCart;

            Update(product, quantity); 
        }

        public virtual Guid ProductID { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual decimal Price { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual decimal Tax { get; protected set; }
        public virtual ShoppingCart ShoppingCart { get; protected set; }

        public virtual decimal SubTotal
        {
            get { return Price * Quantity; }
        }

        public virtual void Update(Product product, int quantity)
        {
            Quantity += quantity;
            Tax = CalculateTax(product);
        }

        private decimal CalculateTax(Product product)
        {
            var taxPerUnit = product.CalcSalesTax() + product.CalcImportDuty();
            return Quantity*taxPerUnit;
        }
    }
}