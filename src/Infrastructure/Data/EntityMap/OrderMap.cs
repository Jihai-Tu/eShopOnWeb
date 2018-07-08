using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.eShopWeb.Infrastructure.Data.EntityMap
{

    class OrderMap : IEntityMap
    {
        public OrderMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Order>();
            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(o => o.ShipToAddress);
        }
    }
}
