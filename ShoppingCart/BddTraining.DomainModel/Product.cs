using System;
using BddTraining.SharpArch.Domain;

namespace BddTraining.DomainModel
{
    public class Product : Entity
    {
        private const decimal NormalProductRate = 0.1m;
        private const decimal FoodRate = 0.2m;

        private const decimal ImportDutyRate = 0.05m;

        public Product() { }

        public virtual string Name { get; protected internal set; }
        public virtual decimal Price { get; protected internal set; }
        public virtual bool IsImported { get; protected internal set; }
        public virtual ProductType Type { get; protected internal set; }

        public virtual decimal CalcSalesTax()
        {
            if (Type == ProductType.Normal)
                return Price * NormalProductRate;

            if (Type == ProductType.Food)
                return Price * FoodRate;

            return 0;
        }

        public virtual decimal CalcImportDuty()
        {
            if (IsImported)
                return Price * ImportDutyRate;

            return 0;
        }
    }
}