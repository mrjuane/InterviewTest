﻿namespace InventoryWebApp.Models
{
    public class ProductAttribute
    {
        public int InstanceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Product Product { get; set; }
    }
}