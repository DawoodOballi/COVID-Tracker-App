using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }
        [Required]
        public string Name { get; set; }
        public long Capacity { get; set; }
        [Required]
        public string Add1 { get; set; }
        [Required]
        public string Add2 { get; set; }
        [Required]
        public string City { get; set; }
        public string Town { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public ICollection<UserCheckin> CheckIns { get; set; }
    }
}
