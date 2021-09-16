using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryWebApp.Models
{
    public class Product
    {
        public int InstanceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProductImageUris { get; set; }
        [Required]
        public string ValidSkus { get; set; }
        public DateTime CreatedTimestamp { get; set; }

        public ICollection<ProductAttribute> ProductAttribute { get; set; }
        public ICollection<Category> Categories { get; set; }

    }

}