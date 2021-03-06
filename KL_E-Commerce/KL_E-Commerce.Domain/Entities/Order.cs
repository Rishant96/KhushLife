﻿using KL_E_Commerce.Domain.Abstract;
using KL_E_Commerce.Domain.Entities.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KL_E_Commerce.Domain.Entities
{
    public class Order 
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderValue { get; set; }
        public IDeliveryProvider DeliveryMethod { get; set; }
        public DateTime DeliverBy { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public virtual IdentityUser User { get; set; }
    }

    public enum OrderStatus
    {
        Processing,
        Dispatched,
        InTransit,
        OutForDelivery
    }
}
