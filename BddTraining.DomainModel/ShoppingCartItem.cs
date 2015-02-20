using System;
using RosterLive.SharpArch.Domain;

namespace BddTraining.DomainModel
{
    public class ShoppingCartItem : Entity
    {
        public ShoppingCartItem() { }

        public ShoppingCartItem(ShoppingCart shopping, Product product, int quantity)
        {
            Initialize(product, quantity);
            ShoppingCart = shopping;
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

        public virtual void Add(Product product, int quantity)
        {
            Quantity += quantity;
            Tax = CalcTax(product);
        }


        private void Initialize(Product product, int quantity)
        {
            ProductID = product.ID;
            Name = product.Name;
            Price = product.Price;

            Add(product, quantity);
        }

        private decimal CalcTax(Product product)
        {
            var taxPerUnit = product.CalcSalesTax() + product.CalcImportDuty();
            return Quantity*taxPerUnit;
        }
    }
}