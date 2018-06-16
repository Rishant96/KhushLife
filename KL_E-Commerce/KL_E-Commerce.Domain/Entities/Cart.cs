using KL_E_Commerce.Domain.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        ICollection<CartItem> CartItems { get; set; }
        public float TotalPrice { get; set; }
        public CartStatus Status { get; set; }
    }

    public enum CartStatus
    {

    }
}
