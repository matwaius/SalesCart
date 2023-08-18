using dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace dotnet_api.Maps
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Base
    {
        private readonly string _tableName;
        public BaseMap(string tableName)
        {
            _tableName = tableName;
        }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if(!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
    public class BaseOrder_ProductMap<T> : IEntityTypeConfiguration<T> where T : Base_Order_Product
    {
            private readonly string _tableName;
            public BaseOrder_ProductMap(string tableName)
            {
                _tableName = tableName;
            }
            public virtual void Configure(EntityTypeBuilder<T> builder)
            {
                if (!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

                builder.HasKey(x => x.orderID);
                builder.HasKey(x => x.productID);
            }
    }
}
