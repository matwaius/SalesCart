using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace dotnet_api.Maps
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap() : base("Product")
        {

        }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.name).HasColumnName("name").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.description).HasColumnName("description").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.price).HasColumnName("price").HasColumnType("decimal(16,7)").IsRequired();
            builder.Property(x => x.created).HasColumnName("created").HasColumnType("datetime2(7)").IsRequired();
        }
    }
}
