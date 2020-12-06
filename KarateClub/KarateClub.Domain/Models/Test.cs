using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarateClub.Domain.Models
{
    public class Test
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }
    }
}
