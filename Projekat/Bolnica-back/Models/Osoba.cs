
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bolnica_back.Models
{

     [Table("OsobaPodaci")]
     public class Osoba
     {
               
               [Column("IME")]
                public string Ime{get;set;}
                
                [Column("PREZIME")]
                public string Prezime{get;set;}

                [Key]
                [Column("JMBG")]
                public string JMBG{get;set;}

                [Column("HITAN_SLUCAJ")]
                public string HitanSlucaj{get;set;}

                 [Column("TIP_OSIGURANJA")]
                public string TipOsiguranja{get;set;}
               
                
               [Column("ODELJENJE")]
                public string TipOdeljenje{get;set;}    //ispravi!!!

                [Column("IDLEKARA")]
                public string IdLek{get;set;}
             
               
               [Column("BROJ_KREVETA")]
                public int Brojk
                {get;set;}

               
               
               [JsonIgnore]
               public Bolnica Bolnica {get;set;}  //Da znamo kojoj bolnici pripada osoba
     }

}