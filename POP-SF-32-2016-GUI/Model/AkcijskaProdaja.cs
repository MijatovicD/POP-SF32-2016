﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class AkcijskaProdaja
    {
        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public decimal Popust { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public List<Namestaj> NamestajNaPopustu { get; set; }
        public bool Obrisan { get; set; }


        public override string ToString()
        {
            return $"{DatumPocetka}, {Popust}, {DatumZavrsetka}";
        }

        public static AkcijskaProdaja GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }
    }
}
