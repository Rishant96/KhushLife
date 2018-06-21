using KL_E_Commerce.Domain.Entities.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class StockedProduct
    {
        [Key]
        public int Id { get; set; }
        public float BasePrice { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public int VendorId { get; set; }
        public virtual IdentityUser Vendor { get; set; }

        public int StockedInStoreId { get; set; }
        public ICollection<StockedInStore> Store { get; set; }

        public virtual ICollection<Utilities.finalSpec> Specifications { get; set; } 
    }
}
