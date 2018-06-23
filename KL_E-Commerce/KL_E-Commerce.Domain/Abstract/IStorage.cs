using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Abstract
{
    public interface IStorage
    {
        int Id { get; set; }
        Address Address { get; set; }
        string VendorId { get; set; }
    }
}
