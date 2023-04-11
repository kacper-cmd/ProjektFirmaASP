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
    public class Aktualnosc
    {
        [Key]//to co nizej jest kluczem glownym tableli 
        public int IdAktualnosci { get; set; }
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(10, ErrorMessage = "Tytul moze zawierac max 10 znakow")]
        [Display(Name = "Tytuł odnośnika do aktualności")]//to nazwe bedzie widzial uzytkownik
        public string LinkTytul { get; set; }
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytul moze zawierac max 30 znakow")]
        [Display(Name = "Tytuł aktualności")]//to nazwe bedzie widzial uzytkownik w formularzu
        public string Tytul { get; set; }
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]//jakiego typu to pole bedzie w bazie danych
        public string Tresc { get; set; }
        [Required(ErrorMessage = "Pozycja jest wymagana")]
        [Display(Name = "Pozycja Wyświetlania")]
        public int Pozycja { get; set; }
        //data dodania, zdjecia, czy aktywne, kto dodal, kiedy dodal, kto edytowal, kiedy edytowal 7 pól zasada 7s
        //kto zmodyfikowal kiedy zmodifikowal 7s na klasde= i dziedziczyc 
        //kiedy usunal kiedy usunac 
    }
}
