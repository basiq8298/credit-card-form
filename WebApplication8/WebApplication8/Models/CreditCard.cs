using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class CreditCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string MailingAddress { get; set; }
        [Required]
        public int CreditLimt { get; set; }
        [Required]
        public int UserId { get; set; }
        
        public PersonalInfo User { get; set; }
    }
}