using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Partnerzy
    {
        [Key]
        public int IdPartnerzy { get; set; }
        [Required(ErrorMessage = "Tytul jest wymagany")]
        [MaxLength(10, ErrorMessage = "Tytul moze zawierac max 10 znakow")]
        [Display(Name = "Tytul odnosnika do strony")]
        public string LinkTytul { get; set; }
        [Required(ErrorMessage = "Tytul jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytul moze zawierac max 30 znakow")]
        [Display(Name = "Tytul strony")]
        public string Tytul { get; set; }
        [Display(Name = "Tresc")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }
        [Display(Name = "Pozycja wyswietlania")]
        [Required(ErrorMessage = "Pozycja jest wymagana")]
        public int Pozycja { get; set; }


    }
}
