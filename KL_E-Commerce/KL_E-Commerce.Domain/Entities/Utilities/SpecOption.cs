
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities.Utilities
{
    public class SpecOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        
        public bool IsSelected { get; set; }
        public bool IsConstrained { get; set; }

        public List<int> Constraints { get; set; } 

        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }
    }
}
