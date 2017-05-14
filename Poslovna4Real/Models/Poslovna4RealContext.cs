using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Poslovna4Real.Models
{
    public class Poslovna4RealContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Poslovna4RealContext() : base("name=Poslovna4RealContext")
        {
        }

        public System.Data.Entity.DbSet<Poslovna4Real.Models.Drzava> Drzavas { get; set; }

        public System.Data.Entity.DbSet<Poslovna4Real.Models.NaseljenoMesto> NaseljenoMestoes { get; set; }
    }
}
