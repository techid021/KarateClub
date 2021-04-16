using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KarateClub.Domain.Models
{
    [Table("Log", Schema = "dbo")]
    public class Log
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(50)]
        public string Level { get; set; }
        public string Message { get; set; }
        [MaxLength(250)]
        public string UserName { get; set; }
        public string ServerName { get; set; }
        [MaxLength(150)]
        public string IP { get; set; }
        [MaxLength(90)]
        public string Controller { get; set; }
        [MaxLength(90)]
        public string Action { get; set; }
        [MaxLength(200)]
        public string Host { get; set; }
        [MaxLength(200)]
        public string Url { get; set; }
        public bool? UserAuthenticated { get; set; }
        [MaxLength(200)]
        public string UserAgent { get; set; }
        [MaxLength(200)]
        public string ThreadName { get; set; }
        [MaxLength(200)]
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}
