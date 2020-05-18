using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public int TourId { get; set; }

        public DateTime DateTimeAdded { get; set; }
    }
}
