﻿using Firma.Data.Data.Sklep;

namespace Firma.PortalWWW.Models.Sklep
{
    //klasa view modelowa wystawia dane view 
    //to jest klasa pomocnicza ktora bedzie sluzyla do tego zeby poprawnie wyswietlac koszyk
    public class DaneDoKoszyka
    {
        //w celu wyswietlenia koszyka mam liste elementow kosyzka oraz jego sumaryczna wartosc
        public List<ElementKoszyka> ElementyKoszyka { get; set;}
        public decimal Razem { get; set;}
    }
}
