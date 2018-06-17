using KL_E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Abstract
{
    public interface IDataProvider
    {
        Vendor Vendor { get; }

        Store Store { get; }

        IEnumerable<Category> Categories { get; }

        IEnumerable<Product> Products { get; }

        Cart Cart { get; }

        Order Order { get; set; }
    }
}
