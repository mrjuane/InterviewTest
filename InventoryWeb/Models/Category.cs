using System.Collections.Generic;

namespace InventoryWeb.Models
{
    public class Category
    {
        public int InstanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedTimestamp { get; set; }

        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public virtual ICollection<Category> Categories1 { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}