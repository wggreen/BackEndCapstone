using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models.ViewModels
{
    public class Conversation
    {
        public bool IsRead { get; set; }
        public ApplicationUser User { get; set; }

        public ApplicationUser UserTwo { get; set; }

        public Messages LastMessage { get; set; }
    }
}
