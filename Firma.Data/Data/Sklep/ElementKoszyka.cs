using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    //to jest klasa ktora bedzie przechowywala wszystkie elementy koszyka danego uzytkownika przegladarki. Jezeli klient bedzie kupowal 5 towarow bedzie mial 5 elementow koszyka
    public class ElementKoszyka
    {
        [Key]
        public int IdElementuKoszyka { get; set; }
        //zapisywac elementy koszyka na sejsi moge tak eleternatywa lokalne 
        public string IdSesjiKoszyka { get; set; }//tu jest przechowywany identyfikator przegladarki - klienta


        public int TowarId { get; set; }//tu jest przechowywany identyfikator towaru
        public Towar Towar { get; set; }
        public int Ilosc { get; set; }//tu jest przechowywana ilosc towaru
        public DateTime DataUtworzenia { get; set; }//tu jest przechowywana data utworzenia elementu koszyka

        

    }
}
