using KL_E_Commerce.Domain.Entities.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class StockedProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Description { get; set; }


        public int VendorId { get; set; }
        public virtual IdentityUser Vendor { get; set; }

        public int StockedInStoreId { get; set; }
        public ICollection<StockedInStore> Store { get; set; }

        public Dictionary<Utilities.Attribute, Utilities.SpecOption> Specifications { get; set; } 
    }
}
