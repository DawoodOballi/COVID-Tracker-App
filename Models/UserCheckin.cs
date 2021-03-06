﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserCheckin
    {
        [Key]
        public int UserCheckinID { get; set; }
        public int UserID { get; set; }
        public int VenueID { get; set; }
        public DateTime CheckedInAt { get; set; }
        public DateTime? CheckedOutAt { get; set; }
        public User User { get; set; }
        public Venue Venue { get; set; }
    }
}
