using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace InventoryWeb.Models
{
    //[Table("Product")]
    //[DataContract]
    public class Product
    {
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImageUris { get; set; }
        public string ValidSkus { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }

        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}