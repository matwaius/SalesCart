﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models.Entities
{
    public class Product : Base
    {
        public string name { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public DateTime? created { get; set; }

    }
}
