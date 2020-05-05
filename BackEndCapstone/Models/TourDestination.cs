using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class TourDestination
    {

        [Key]
        public int Id { get; set; }

        public int TourId { get; set; }

        public int DestinationId { get; set; }

        public string Date { get; set; }

        public string payment { get; set; }
    }
}
