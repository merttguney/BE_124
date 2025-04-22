using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

namespace App.Web.Mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required,Range(0,double.MaxValue)]
        public double Price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public string? Image { get; set; }
    }
}
