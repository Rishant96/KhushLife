using KL_E_Commerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Category : IDisplayable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Utilities.Attribute> Attributes { get; set; }
        [Required]
        public bool IsBase { get; set; }

        public int DisplayOrder { get; set; }
        
        public int? CategoryId { get; set; }
        public virtual Category Parent { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [NotMapped]
        public List<Category> ChildCategories { get; set; }
    }
}
