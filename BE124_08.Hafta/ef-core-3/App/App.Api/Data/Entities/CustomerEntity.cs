﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Api.Data.Entities
{
    public class CustomerEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required, MaxLength(50)]
        public string Name { get; set; } = null!; // null olmayacak demek (String.Empty de kullanılabilir)


        [Required,EmailAddress]
        public string Email { get; set; }


        [Required,Phone]
        public string Phone { get; set; }


        // Navigation property
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
