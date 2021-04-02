using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KarateClub.Domain.Models
{
    [Table("Coach", Schema = "Info")]
    public class Coach
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(80)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Rank { get; set; }
        public byte[] Image { get; set; }
        public DateTime InsertDate { get; set; }
        public byte IsActive { get; set; }
        public string Extention { get; set; }
        public string ImageTitle { get; set; }
        public string Description { get; set; }
    }
}
