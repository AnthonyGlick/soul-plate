using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string AddressOne { get; set }

        public string City { get;set }
        
        public string State { get; set; }

        public int PostalCode { get; set; }

    }
}
