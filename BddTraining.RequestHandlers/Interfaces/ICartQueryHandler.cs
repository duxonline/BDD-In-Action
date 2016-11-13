using System;
using BddTraining.DomainModel;

namespace BddTraining.RequestHandlers.Interfaces
{
    public interface ICartQueryHandler
    {
        ShoppingCart GetCartDetails(Guid cartCreatedId);
    }
}
