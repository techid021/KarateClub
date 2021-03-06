using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KarateClub.Domain.Models
{
    [Table("News", Schema = "Info")]
    public class News
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public byte? IsActive { get; set; }
        public byte? ShowInSlider { get; set; }
        public byte?[] Image { get; set; }
        public byte Notification { get; set; }
    }
}
