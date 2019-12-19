using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budget.Models
{
    public class Ecriture
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public bool Debit { get; set; }
        [Required]
        public decimal Montant { get; set; }

        public Guid IdCompte { get; set; }
    }
}
