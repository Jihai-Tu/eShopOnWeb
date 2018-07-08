using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.eShopWeb.Infrastructure.Data.EntityMap
{

    class CatalogBrandMap : IEntityMap
    {
        public CatalogBrandMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<CatalogBrand>();

            builder.ToTable("CatalogBrand");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_brand_hilo")
                .IsRequired();

            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
