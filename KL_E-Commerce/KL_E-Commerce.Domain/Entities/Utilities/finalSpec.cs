using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities.Utilities
{
    public class FinalSpec
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; }

        public int StockedProductId { get; set; }
        public virtual StockedProduct StockedProduct { get; set; }
    }
}
