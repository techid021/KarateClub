using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KarateClub.Domain.Models
{
    [Table("Year", Schema = "Base")]
    public class Year
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public long Value { get; set; }
    }
}
