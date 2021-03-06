﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF32_2016.Model
{
    public class TipNamestaja
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Obrisan { get; set; }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Id == id)
                {
                    return tip;
                }
            }
            return null;
        }
    }
}
