using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace dotnet_api.Maps
{
    public class Order_ProductMap : BaseOrder_ProductMap<Order_Product>
    {

        public Order_ProductMap() : base("Order_Product")
        {

        }

        public override void Configure(EntityTypeBuilder<Order_Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.orderID).HasColumnName("orderID").HasColumnType("int").IsRequired();
            builder.Property(x => x.productID).HasColumnName("productID").HasColumnType("int").IsRequired();
            builder.Property(x => x.quantity).HasColumnName("quantity").HasColumnType("int").IsRequired();
            builder.Property(x => x.created_at).HasColumnName("created_at").HasColumnType("datetime2(7)").IsRequired();
            builder.Property(x => x.unit_price).HasColumnName("unit_price").HasColumnType("decimal(16,7)").IsRequired();
            builder.Property(x => x.total_price).HasColumnName("total_price").HasColumnType("decimal(16,7").IsRequired();
        }
    }
}
