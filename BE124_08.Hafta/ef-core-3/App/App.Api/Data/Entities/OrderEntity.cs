using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Api.Data.Entities
{
    public class OrderEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }


        // navigation property

        //[ForeignKey(nameof(CustomerId))]
        [JsonIgnore]
        public CustomerEntity Customer { get; set; } = null!;
        

    }

    // FLUENT API

    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x => x.OrderDate).HasDefaultValueSql("GETDATE()");

            // One to many ilişki
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

            builder.Property(nameof(OrderEntity.OrderNumber)).IsRequired();
        }
    }

}
