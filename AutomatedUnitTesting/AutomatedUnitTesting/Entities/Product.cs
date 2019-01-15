using System;
using System.Collections.Generic;

namespace AutomatedUnitTesting.Entities
{
    public class Product
    {
        public Guid ID { get; set; }
        public Guid StoreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InternalCode { get; set; }
        public virtual ICollection<Sku> Skus { get; set; }
    }
}
