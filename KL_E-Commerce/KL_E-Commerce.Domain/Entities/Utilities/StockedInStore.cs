using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities.Utilities
{
    public class StockedInStore
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int? Stock { get; set; }
        public bool IsStocked { get; set; }
        public ProductStatus Status { get; set; }
    
        public string VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        public int StockedProductId { get; set; }
        public virtual StockedProduct StockedProduct { get; set; }
    }

    public enum ProductStatus
    {
        OutOfStock,
        InStock,
        NewArrival,
        ComingSoon
    }
}
