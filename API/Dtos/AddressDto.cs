﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddressDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
