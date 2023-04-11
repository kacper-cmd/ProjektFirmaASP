using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Rodzaj
    {
        [Key]//to co nizej jest kluczem glownym tableli
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "nazwa moze zawierac max 30 znakow")]

        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public List<Towar> Towar { get; set; }//to jest realizacja relacji jeden do wielu jeden roadzaj ma wiele towarow danego rodzaju
    }
}
