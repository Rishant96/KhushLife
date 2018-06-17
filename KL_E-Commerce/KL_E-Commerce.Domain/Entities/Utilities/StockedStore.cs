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
        public int Stock { get; set; }
        public ProductStatus Status { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public enum ProductStatus
    {
        OutOfStock,
        InStock,
        NotListed
    }
}
