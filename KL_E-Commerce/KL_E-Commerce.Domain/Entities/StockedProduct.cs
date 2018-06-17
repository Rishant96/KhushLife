using KL_E_Commerce.Domain.Abstract;
using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class StockedProduct : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<StockedInStore> StockedStores { get; set; }
        
        public virtual ICollection<StockedProductSpec> GetStockedProductSpecs { get; set; }
    }
}
