using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KL_E_Commerce.Web.Areas.Vendors.Models
{
    public class IndexProductViewModel
    {
        public List<Product> Products { get; set; }
        public int Id { get; set; }
    }

    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public List<Domain.Entities.Utilities.Attribute> Attributes { get; set; }
        public int Id { get; set; }
    }
}