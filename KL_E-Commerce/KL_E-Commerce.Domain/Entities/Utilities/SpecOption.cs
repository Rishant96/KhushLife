
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
        public string Value { get; set; }
        public float SpecCost { get; set; }

        public bool IsSelected { get; set; }
        public bool IsPreSelected { get; set; }
        public bool HasConstraints { get; set; }

        public List<int> SpecConstraints { get; set; }

        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }
    }
}
