using Microsoft.EntityFrameworkCore;

namespace Bolnica_back.Models
{

    
   public class BolnicaContext : DbContext
   {
       public DbSet<Bolnica> Bolnice{get;set;}
       public DbSet<Osoba> Osobe{get;set;}
       public DbSet<Lekar> Lekari{get;set;}

        public BolnicaContext(DbContextOptions options) : base(options)
        {
                
        }

   }

}