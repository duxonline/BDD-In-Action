using System;
using BddTraining.DomainModel;
using FluentNHibernate.Mapping;
using NHibernate.Id;

namespace BddTraining.Repositories.Maps
{
    public class ShoppingCartItemMap : ClassMap<ShoppingCartItem>
    {
        public ShoppingCartItemMap()
        {
            Id(x => x.ID).UnsavedValue(Guid.Empty)
                .GeneratedBy.Custom(typeof (GuidCombGenerator));

            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.ProductID);
            Map(x => x.Quantity);
            Map(x => x.Tax);
            References(x => x.ShoppingCart, "ShoppingCartID");
        }
    }
}
