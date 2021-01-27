using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bolnica_back.Models
{

[Table("BolnicaPodaci")]
public class Bolnica
{
    
    [Column("IME")]
     public string Ime
     {
         get;
         set;
     }
     
     [Key]
     [Column("ID")]
     public int ID
     {
         get;set;
     }
     
     [Column("N")]
     public int N
     {
         get;set;
     }

    [Column("M")]
     public int M
     {
         get;set;
     }
     
     public virtual List<Osoba> Osobe{get;set;}  //pokazivac na drugu tabelu, kolekcija necega
     public virtual List<Lekar> Lekari{get;set;}

}
}