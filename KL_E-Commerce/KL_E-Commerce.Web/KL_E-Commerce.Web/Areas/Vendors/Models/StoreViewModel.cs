using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL_E_Commerce.Web.Areas.Vendors.Models
{
    public class IndexStoreViewModel
    {
        public List<Store> Stores { get; set; }
        public Dictionary<Store, List<StockedInStore>> StockedProducts { get; set; }
    }

    public class CreateStoreViewModel
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}