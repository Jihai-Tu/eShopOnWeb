using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.eShopWeb.Infrastructure.Data.EntityMap
{

    class OrderItemMap : IEntityMap
    {
        public OrderItemMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<OrderItem>();
            builder.OwnsOne(i => i.ItemOrdered);

        }
    }
}
