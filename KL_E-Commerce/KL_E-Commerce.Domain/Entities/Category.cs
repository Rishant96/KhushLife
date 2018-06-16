using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Utilities.Attribute> Attributes { get; set; }
        public bool IsBase { get; set; }

        public int CategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
