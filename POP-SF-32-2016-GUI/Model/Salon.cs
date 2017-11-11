﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class Salon
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string InternetAdresa { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public string ZiroRacun { get; set; }
        public bool Obrisan { get; set; }

        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Telefon}, {Email}, {InternetAdresa}, {PIB}, {MaticniBroj}, {ZiroRacun}";
        }
    }
}