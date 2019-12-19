using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Banque
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Ville { get; set; }
    }
}
