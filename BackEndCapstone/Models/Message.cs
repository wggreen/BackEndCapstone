using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCapstone.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string MessageText { get; set; }

        public DateTime Timestamp { get; set; }

        public string FormattedTimestamp { get; set; }

    }
}
