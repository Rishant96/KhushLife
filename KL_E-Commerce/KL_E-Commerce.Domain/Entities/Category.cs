using KL_E_Commerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Category : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Utilities.Attribute> Attributes { get; set; }
        public bool IsBase { get; private set; }

        public int DisplayOrder { get; set; }

        public ICollection<Category> ChildCategories { get; set; }

        public Category(string name, bool isBase = true)
        {
            Name = name;
            IsBase = isBase;
        }

        public Category(string name, Category parent) :
            this(name, false)
        {
            this.Attributes = new List<Utilities.Attribute>(parent.Attributes);
        }
    }
}
