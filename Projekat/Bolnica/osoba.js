export class Osoba
{
      constructor(Ime,Prezime,JMBG,HitanSlucaj,TipOsiguranja,Odeljenje,BrojKreveta,IDLek){
          this.Ime=Ime;
          this.Prezime=Prezime;
          this.HitanSlucaj=HitanSlucaj;
          this.TipOsiguranja=TipOsiguranja;
          this.Odeljenje=Odeljenje;
          this.kontOs=null;
          this.JMBG=JMBG;
          this.BrojKreveta=BrojKreveta;
          this.IDLek=IDLek;
      }

      prikaziOsobu(host){
             this.kontOs=document.createElement("div");
             this.kontOs.className="kontOs";
             this.kontOs.innerHTML=this.Ime + " "+ this.Prezime + "<br/>"  + this.JMBG  + "<br/>"  + this.IDLek;
             host.appendChild(this.kontOs);
      }

      azurirajOsobu(Ime,Prezime,JMBG,HitanSlucaj,TipOsiguranja,Odeljenje,BrojKreveta,IDLek){
       this.Ime=Ime;
       this.Prezime=Prezime;
       this.HitanSlucaj=HitanSlucaj;
       this.TipOsiguranja=TipOsiguranja;
       this.Odeljenje=Odeljenje;
       this.JMBG=JMBG;
       this.IDLek=IDLek;
       if(this.Ime==="Prazan")
       {
       this.kontOs.innerHTML=this.Ime + " "+ this.Prezime + "<br/>"+this.JMBG + "<br/>" +this.IDLek;
       }
       else
       {
              this.kontOs.innerHTML=this.Ime + " "+ this.Prezime + "<br/>"+"Sifra: "+this.JMBG + "<br/>" +"LekarID: "+this.IDLek;
       }
       this.BrojKreveta=BrojKreveta;
       
       } 
      
      

}