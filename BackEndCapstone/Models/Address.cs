using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Address
    {

        public int Id { get; set; }

        public string FullAddress { get; set; }

        public string Name { get; set; }

        public string Blurb { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }
    }
}
