using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firma.Data.Data.CMS
{
    //tworzymy klase z ktorej bedzie automatycznie prze entity framework generowal tabele w bazie danych
    public class Strona
    {
        [Key]//to co nizej jest kluczem glownym tableli 
        public int IdStrony { get; set; }
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(10, ErrorMessage = "Tytul moze zawierac max 10 znakow")]
        [Display(Name = "Tytuł odnośnika do strony")]//to nazwe bedzie widzial uzytkownik
        public string LinkTytul { get; set; }
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytul moze zawierac max 30 znakow")]
        [Display(Name = "Tytuł strony")]//to nazwe bedzie widzial uzytkownik w formularzu
        public string Tytul { get; set; }
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]//jakiego typu to pole bedzie w bazie danych
        public string Tresc { get; set; }
        [Required(ErrorMessage = "Pozycja jest wymagana")]
        [Display(Name = "Pozycja Wyświetlania")]
        public int Pozycja { get; set; }
    }
}
