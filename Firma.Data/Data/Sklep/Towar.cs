using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class Towar : TEntity
    {
        [Key]
        public int IdTowaru { get; set; }
        [Required(ErrorMessage = "Kod jest wymagany")]
        public string Kod { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]//jakiego typu to pole bedzie w bazie danych
        public decimal Cena { get; set; }
        [Display(Name = "Wybierz zdjęcie")]
        [Required(ErrorMessage = "Zdjecie jest wymagane")]
        public string FotoUrl { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[]? FotoData { get; set; }
        public string Opis { get; set; }
        //jeden do wielu realizacja klucza obcego
        [Display(Name = "Wybierz rodzaj towaru")]
        public int RodzajId { get; set; }
        public Rodzaj Rodzaj { get; set; }
    }
}
