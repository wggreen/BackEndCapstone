using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models.ViewModels
{
    public class MapEditViewModel
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }

        public string ApplicationUserId { get; set; }

        public Tour TourToEdit { get; set; }

        public List<Destination> Destinations { get; set; }
    }
}
