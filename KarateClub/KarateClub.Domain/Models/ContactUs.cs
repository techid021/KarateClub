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
        public long Id { get; set; } = 0;

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را بصورت کامل وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا متن پیام را وارد کنید")]
        public string Comment { get; set; }
        public byte? IsRead { get; set; } = 0;

        [MaxLength(30)]
        public string IP { get; set; } = "UnKnown";
        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
