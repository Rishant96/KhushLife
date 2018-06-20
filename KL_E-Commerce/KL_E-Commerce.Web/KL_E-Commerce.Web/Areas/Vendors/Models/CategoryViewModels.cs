using KL_E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KL_E_Commerce.Web.Areas.Vendors.Models
{
    public class IndexCategoryViewModel
    {
        public List<Category> Categories { get; set; }
    }

    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Domain.Entities.Utilities.Attribute> Attributes { get; set; }
        public bool IsBase { get; set; }
        public int ParentId { get; set; }    
        public int? Id { get; set; }
    }

    public class AddAttributeViewModel
    {
        [Required]
        [Display(Name = "Attribute Name")]
        public string AtrbName { get; set; }
    }
}