using System;
using FluentNHibernate.Mapping;
using NHibernate.Id;

namespace BddTraining.DomainModel.Repositories.Maps
{
    public class ShoppingCartMap : ClassMap<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            Id(x => x.ID).UnsavedValue(Guid.Empty)
                .GeneratedBy.Custom(typeof(GuidCombGenerator));

            HasMany(x => x.CartItems)
                .Access.CamelCaseField()
                .KeyColumn("ShoppingCartID")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
