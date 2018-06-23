using KL_E_Commerce.Domain.Abstract;
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
    public class Store : IStorage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }

        public string VendorId { get; set; }
        public IdentityUser Vendor { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
