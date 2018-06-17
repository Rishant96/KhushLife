using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities.Utilities
{
    public class Specification
    {
        public int Id { get; set; }
        public bool IsVariable { get; set; }

        public virtual ICollection<SpecOption> SpecOptions { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
