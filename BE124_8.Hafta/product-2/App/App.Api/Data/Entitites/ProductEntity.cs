using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Api.Data.Entitites
{
    public class ProductEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SellerId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [Range(0, int.MaxValue,ErrorMessage = "Only positive")]
        public int Stock { get; set; }

        [ForeignKey(nameof(SellerId))]
        public SellerEntity Seller { get; set; }
    }
}
