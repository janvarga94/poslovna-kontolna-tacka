using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poslovna4Real.Models
{
    public class Drzava
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual List<NaseljenoMesto> NaseljenaMesta { get; set; }
    }
}