using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Vendor : User
    {
        public ICollection<Address> Addresses { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
