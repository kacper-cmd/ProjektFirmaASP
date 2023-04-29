using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Parametry
    {
        [Key]
        public int IdParametru { get; set; }
        [Required(ErrorMessage = "Wartosc jest wymagana")]
        [MaxLength(10, ErrorMessage = "Tytul moze zawierac max 10 znakow")]
        [Display(Name = "Tytul odnosnika do strony")]
        public string Wartosc { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Opis { get; set; }
    }
}
