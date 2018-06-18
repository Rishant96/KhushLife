using KL_E_Commerce.Domain.Abstract;
using KL_E_Commerce.Domain.Entities.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Store : IStorage
    {
        public int Id { get; set; }
        public Address Address { get; set; }

        public int VendorId { get; set; }
        public IdentityUser Vendor { get; set; }
    }
}
