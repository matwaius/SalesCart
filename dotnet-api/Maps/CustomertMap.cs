using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace dotnet_api.Maps
{
    public class CustomerMap : BaseMap<Customer>
    {
        public CustomerMap() : base("Customer")
        {

        }

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.name).HasColumnName("name").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.login).HasColumnName("login").HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.password).HasColumnName("password").HasColumnType("varchar(20)").IsRequired();
        }
    }
}
