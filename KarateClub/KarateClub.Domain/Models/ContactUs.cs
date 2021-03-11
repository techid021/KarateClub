using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KarateClub.Domain.Models
{
    [Table("ContactUs", Schema = "Opinion")]
    public class ContactUs
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        public string Comment { get; set; }
        public byte? IsRead { get; set; }

        [MaxLength(30)]
        public string IP { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
