using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models.Entities
{
    public class Orders : Base
    {
        public int customerID { get; set; }

        public decimal total_order { get; set; }

        public DateTime? created_at { get; set; }

        public string comments { get; set; }

    }
}
