using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Messages
    {
        [Key]
        public int MessagesId { get; set; }

        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; }

        public string MessageText { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsRead { get; set; }

    }
}
