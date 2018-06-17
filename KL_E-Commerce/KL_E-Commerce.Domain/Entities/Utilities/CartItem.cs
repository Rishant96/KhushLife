using KL_E_Commerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities.Utilities
{
    public class CartItem
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public CartItemStatus Status { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }

    public enum CartItemStatus
    {
        NoChange,
        PriceChanged,
        StockChanged
    }
}
