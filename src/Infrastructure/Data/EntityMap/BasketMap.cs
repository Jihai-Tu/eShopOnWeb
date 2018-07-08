using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.eShopWeb.Infrastructure.Data.EntityMap
{
    class BasketMap : IEntityMap
    {
        public BasketMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Basket>();
            var navigation = builder.Metadata.FindNavigation(nameof(Basket.Items));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
