using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Poslovna4Real.Models
{
    public class NaseljenoMesto
    {
        public int Id { get; set; }
        public string PTT { get; set; }
        public string Naziv { get; set; }

        
        public int DrzavaId { get; set; }
        [ForeignKey("DrzavaId")]
        public Drzava Drzava { get; set; }
    }
}