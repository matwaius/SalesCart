using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models.Entities
{
    public class Customer : Base
    {
        public string name { get; set; }

        public string login { get; set; }

        public string password { get; set; }

    }
}
