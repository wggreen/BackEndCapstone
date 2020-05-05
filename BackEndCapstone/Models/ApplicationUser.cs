﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace BackEndCapstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string UserType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Capacity { get; set; }

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        
        public string Address2 { get; set; }

        public string Zip { get; set; }

        public string Website { get; set; }

        public string Facebook { get; set; }
        
        public string Instagram { get; set; }

        public string Twitter { get; set; }

        public string Bandcamp { get; set; }

        public string Youtube { get; set; }

        public string Spotify { get; set; }

        public string Blurb { get; set; }

    }
}