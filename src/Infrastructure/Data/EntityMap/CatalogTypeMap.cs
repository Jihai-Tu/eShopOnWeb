using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.eShopWeb.Infrastructure.Data.EntityMap
{

    class CatalogTypeMap : IEntityMap
    {
        public CatalogTypeMap(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<CatalogType>();

            builder.ToTable("CatalogType");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo")
                .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
