using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.Infrastructure.Data.EntityMap;

namespace Microsoft.eShopWeb.Infrastructure.Data
{

    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddAllEntityTypes(modelBuilder);
            MapAllEntityTypes(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 找到所有继承自BaseEntity的实体，动态添加实体类型
        /// </summary>
        /// <param name="builder"></param>
        private static void AddAllEntityTypes(ModelBuilder builder)
        {
            var entityTypes = typeof(BaseEntity).Assembly.GetTypes()
                .Where(t => t.IsClass && typeof(BaseEntity).IsAssignableFrom(t) && t != typeof(BaseEntity));
            foreach (var entityType in entityTypes)
            {
                if (builder.Model.FindEntityType(entityType) == null)
                {
                    builder.Model.AddEntityType(entityType);
                }
            }
        }

        /// <summary>
        /// 找到所有实现IEntityMap的类型，动态进行实体映射
        /// </summary>
        /// <param name="builder"></param>
        private static void MapAllEntityTypes(ModelBuilder builder)
        {
            var entityMaps = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace)
                               && typeof(IEntityMap).IsAssignableFrom(type) && type.IsClass).ToList();

            foreach (var entyMap in entityMaps)
            {
                Activator.CreateInstance(entyMap, builder);
            }
        }
    }
}
