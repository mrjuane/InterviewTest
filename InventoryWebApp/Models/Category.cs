using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryWebApp.Models
{
    public class Category
    {
        public int InstanceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }

        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public ICollection<Category> Categories1 { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}