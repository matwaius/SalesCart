using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models.Entities
{
    public class Order_Product : Base_Order_Product
    {
        public int quantity { get; set; }

        public DateTime? created_at { get; set; }

        public decimal unit_price { get; set; }

        public decimal total_price { get; set; }

    }
}
