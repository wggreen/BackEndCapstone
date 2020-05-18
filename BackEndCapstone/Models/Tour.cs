using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Tour
    {

        [Key]
        public int TourId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public bool Saved { get; set; }

        public List<Destination> Destinations {get;set;}
    }
}
