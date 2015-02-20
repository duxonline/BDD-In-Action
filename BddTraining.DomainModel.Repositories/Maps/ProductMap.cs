using System;
using FluentNHibernate.Mapping;
using NHibernate.Id;

namespace BddTraining.DomainModel.Repositories.Maps
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ID).UnsavedValue(Guid.Empty)
                .GeneratedBy.Custom(typeof (GuidCombGenerator));

            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.IsImported);
            Map(x => x.Type).CustomType<int>();
        }
    }
}
