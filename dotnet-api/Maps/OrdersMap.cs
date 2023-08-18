using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace dotnet_api.Maps
{
    public class OrdersMap : BaseMap<Orders>
    {
        public OrdersMap() : base("Orders")
        {

        }

        public override void Configure(EntityTypeBuilder<Orders> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.customerID).HasColumnName("customerID").HasColumnType("int").IsRequired();
            builder.Property(x => x.total_order).HasColumnName("total_order").HasColumnType("decimal(16,7)").IsRequired();
            builder.Property(x => x.created_at).HasColumnName("created_at").HasColumnType("datetime2(7)").IsRequired();
            builder.Property(x => x.comments).HasColumnName("comments").HasColumnType("varchar(255)").IsRequired();
        }
    }
}
