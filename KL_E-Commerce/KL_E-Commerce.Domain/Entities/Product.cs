using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<StockedStore> StockedStores { get; set; }
        public ProductStatus Status { get; set; }
        public ICollection<Specification> Specifications { get; set; }
        public ICollection<Utilities.Attribute> ExtraAttributes { get; set; }
    }

    public enum ProductStatus
    {
    }
}
