using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bolnica_back.Models
{

     [Table("LekarPodaci")]
     public class Lekar
     {
               
                [Column("IME")]
                public string Ime{get;set;}
                
                [Column("PREZIME")]
                public string Prezime{get;set;}

                [Key]
                [Column("IDLekara")]
                public string IDLekara{get;set;}
 
                [Column("SPECIJALIZACIJA")]
                public string Specijalizacija{get;set;}   
             
                [JsonIgnore]
                public Bolnica Bolnica {get;set;}  //Da znamo kojoj bolnici pripada osoba
     }

}