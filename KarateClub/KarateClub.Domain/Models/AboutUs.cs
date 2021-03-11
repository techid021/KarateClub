using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarateClub.Domain.Models
{
    [Table("AboutUs", Schema = "Info")]
    public class AboutUs
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(80)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(40)]
        public string Phone { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
