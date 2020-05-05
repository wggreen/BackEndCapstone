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
        public int Id { get; set; }

        public int VenueId { get; set; }
    }
}
