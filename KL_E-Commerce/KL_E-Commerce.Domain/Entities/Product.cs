using KL_E_Commerce.Domain.Abstract;
using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Product : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool HasVariants { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public Dictionary<Utilities.Attribute, Specification> Specifications { get; private set; }
        
        public Product(string name, int categoryId)
        {
            this.Name = name;
            this.CategoryId = categoryId;
        }

        public void setSpecifications(ICollection<Specification> specifications)
        {
            int i = 0;
            foreach(var atr in Category.Attributes)
            {
                this.Specifications.Add(atr, specifications.ElementAt(i++));
            }
        }
    }
}
