using System;
using BddTraining.DomainModel;

namespace BddTraining.RequestHandlers.Interfaces
{
    public interface IShoppingCartRetriever
    {
        ShoppingCart Get(Guid? cartId);
    }
}
