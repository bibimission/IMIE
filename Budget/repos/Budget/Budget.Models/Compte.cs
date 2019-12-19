using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public enum TypeDeCompte
    {
        Courant,
        Epargne,
        Pret
    }

    public class Compte
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public uint Numero { get; set; }
        [Required]
        [EnumDataType(typeof(TypeDeCompte))]
        public TypeDeCompte Type { get; set; }

        public Guid IdPersonne { get; set; }
        public Guid IdBanque { get; set; }


    }
}
