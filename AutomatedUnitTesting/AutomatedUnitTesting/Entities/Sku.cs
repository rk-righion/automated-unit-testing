using System;

namespace AutomatedUnitTesting.Entities
{
    public class Sku
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public string PartNumber { get; set; }
        public decimal ListPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
