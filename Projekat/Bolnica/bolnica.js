
import { Osoba } from "./osoba.js";
import {Lekar} from "./lekar.js"


export class Bolnica
{
     constructor(naziv,id,n,m){
          this.naziv=naziv;
          this.id=id;
          this.kontejner=null;
          this.nizOsoba=[];
          this.n=n;
          this.m=m;
          this.brZauzetihKreveta=0;
          this.nizLekara=[];
     }

     dodajOsobu(od){
         this.nizOsoba.push(od);
     }

     dodajLekara(lekar){
        this.nizLekara.push(lekar);
     }

     nadjiLekara(id)
     {
     
      for(let i=0;i<this.nizLekara.length;i++)
      {
         if(this.nizLekara[i].idLekara===id)  
         {
           
          return this.nizLekara[i];
         }
      }
     }

     prikaziBolnicu(host){
         if(!host)
             throw new Exception("Doslo je do greske");
            this.kontejner=document.createElement("div");

            this.kontejner.classList.add("kontejner");
            host.appendChild(this.kontejner);

            this.prikaziFormu(this.kontejner);
            this.prikaziOsobe(this.kontejner);
            this.prikaziFormuZaOtpustanje(this.kontejner);

     }

     pronadjiPraznoMesto()
     {
       for(let i=0;i<this.nizOsoba.length;i++)
       {
          if(this.nizOsoba[i].JMBG==="")  
           return i;
       }
     }


     KreirajOpciju(Ime,Vrednost,ele) {
        let opcija=document.createElement("option");
        opcija.innerHTML=Ime;
        opcija.value=Vrednost;
        ele.appendChild(opcija);
     }

     prikaziFormu(host){


            const kontForma=document.createElement("div");
            kontForma.className="kontForma";
            host.appendChild(kontForma);

            let el=document.createElement("h3");
            el.innerHTML="Prijem u bolnicu";
            kontForma.appendChild(el);

            el = document.createElement("label");
            el.innerHTML="Ime";
            kontForma.appendChild(el);

            let it = document.createElement("input");
            it.type=Text;
            kontForma.appendChild(it);

            el = document.createElement("label");
            el.innerHTML="Prezime";
            kontForma.appendChild(el);

             it = document.createElement("input");
            kontForma.appendChild(it);

            el = document.createElement("label");
            el.innerHTML="Sifra pacijenta";
            kontForma.appendChild(el);

             it = document.createElement("input");
      
            kontForma.appendChild(it);

            let divC=document.createElement("div");
            kontForma.appendChild(divC);

            el=document.createElement("label");
            el.innerHTML="Hitan slucaj";
            divC.appendChild(el);

            it=document.createElement("input");
            it.type="checkbox";
            divC.appendChild(it);

            el=document.createElement("label");
            el.innerHTML="Tip osiguranja :"
            kontForma.appendChild(el);

            let divR=document.createElement("div");
            kontForma.appendChild(divR);
            
            it=document.createElement("input");
            it.type="radio";
            it.name="rb";
            divR.appendChild(it);

           
            el=document.createElement("label");
            el.innerHTML="Drzavno";
            divR.appendChild(el);

        
            divR=document.createElement("div");
            kontForma.appendChild(divR);

            it=document.createElement("input");
            it.type="radio";
            it.name="rb";
            divR.appendChild(it);

            el=document.createElement("label");
            el.innerHTML="Privatno";
            divR.appendChild(el);

            el=document.createElement("label");
            el.innerHTML="Odeljenje :"
            kontForma.appendChild(el);

            let sel=document.createElement("select");
            

            this.KreirajOpciju("Hirurgija",0,sel);
            this.KreirajOpciju("Interno",1,sel);
            this.KreirajOpciju("Urologija",2,sel);
            this.KreirajOpciju("Neurologija",3,sel);
            this.KreirajOpciju("Nefrologija",4,sel);
            this.KreirajOpciju("Infektivno",5,sel);
            this.KreirajOpciju("Pedijatrija",6,sel);
            this.KreirajOpciju("Oftalmologija",7,sel);
            this.KreirajOpciju("Ginekologija",8,sel);

            kontForma.appendChild(sel);


            el = document.createElement("label");
            el.innerHTML="ID lekara";
            kontForma.appendChild(el);

            it = document.createElement("input");
            it.type=Text;
            kontForma.appendChild(it);
    
            const dugme=document.createElement("button");
            dugme.innerHTML="Dodaj pacijenta";
            kontForma.appendChild(dugme); 
           
            dugme.onclick=(ev)=>{

            if(this.brZauzetihKreveta>=this.n*this.m)
            {
              alert("Nema vise mesta.");
            }
            else
            {
              //povecaj brojac
                 let p=this.kontejner.querySelectorAll("input");
                 let Ime=p[0].value;
                 let Prezime=p[1].value;
                 let Jmbg=p[2].value;
                 let hs;
                 let idLekara;
                 if(p[3].checked===true)
                 {
                 hs="Hitan slucaj";
                 }
                 else
                 {
                 hs="Nije hitan slucaj";
                 }
                 let TipO;
                 if(p[4].checked===true)
                 {
                 TipO="Drzavno osiguranje";
                 }
                 else
                 {
                   TipO="Privtano osiguranje";
                 }
                let Odeljenje=sel.options[sel.selectedIndex].text;
                let brKrev=this.pronadjiPraznoMesto();
                idLekara=p[6].value;
                let lekar=this.nadjiLekara(idLekara);
              
                

                if(Jmbg==="")
                {
                       alert("Morate uneti sifru pacijenta!");
                }
                else
                {

                  if((lekar==null) || !(Odeljenje===lekar.specijalizacija)) 
                  {
                    alert("Pogresan Id lekara");
                  }
                  else
                  {

                  let lek=lekar.ime + lekar.prezime;
                  
                  fetch("https://localhost:5001/Bolnica/UpisiOsobu/" + this.id ,{
                    method:"POST",
                    headers : {
                      "Content-Type" : "application/json"
                    },
                    body: JSON.stringify({
                     ime: Ime,
                     prezime: Prezime,
                     jmbg: Jmbg,
                     HitanSlucaj: hs,
                     TipOsiguranja: TipO,
                     TipOdeljenje: Odeljenje,
                     brojk: brKrev,
                     idlek: idLekara
                    })
                 }).then(p=>{
                     if(p.ok)
                     this.nizOsoba[brKrev].azurirajOsobu(Ime,Prezime,Jmbg,hs,TipO,Odeljenje,brKrev,idLekara);
                     else
                       alert("Doslo je do greske prilikom upisa.");
                 }).catch(p => {
                   alert("Greška prilikom upisa.");
                                });
                  
                   this.brZauzetihKreveta++;
               }
               }
              }

            }
                

           

            
           

     }
    

     prikaziOsobe(host)
     {
           let i=0;

           const kontOdeljenja=document.createElement("div");
           kontOdeljenja.className="kontOdeljenja";
           host.appendChild(kontOdeljenja);
           
           let el=document.createElement("h3");
           el.innerHTML=this.naziv;
           el.className="nas";
           kontOdeljenja.appendChild(el);

           let red;
           let o;
           for(let i=0;i<this.m;i++){
             red=document.createElement("div");
             red.className="red";
             kontOdeljenja.appendChild(red);
             for(let j=0;j<this.n;j++){
                   o=new Osoba("Prazan","krevet","","","","","","");
                   this.dodajOsobu(o);
                   o.prikaziOsobu(red);
             }


           }

           
           
     }
  

     prikaziFormuZaOtpustanje(host)
{
            const kontForma2=document.createElement("div");
            kontForma2.className="kontForma";
            host.appendChild(kontForma2);

            let el=document.createElement("h3");
            el.innerHTML="Otpustanje iz bolnice";
            kontForma2.appendChild(el);

            el = document.createElement("label");
            el.innerHTML="Sifra pacijenta";
            kontForma2.appendChild(el);

            let it = document.createElement("input");
            it.type=Text;
            kontForma2.appendChild(it);


            const dugme=document.createElement("button");
            dugme.innerHTML="Otpusti pacijenta";
            kontForma2.appendChild(dugme); 

            
            let la=document.createElement("div");
               kontForma2.appendChild(la);

            dugme.onclick=(ev)=>{
             
              let p=kontForma2.querySelector("input");
              let brk=this.PronadjiOsobu(p.value).BrojKreveta;
              let o=this.PronadjiOsobu(p.value);


              //Prikaz pacijenta

               
               la.innerHTML="<br/>"+ "<br/>"+"Otpusten pacijent:" + "<br/>" + o.Ime + " " + o.Prezime + " "+ o.JMBG;
               

               


              //

              
              fetch("https://localhost:5001/Bolnica/IzbrisiOsobu/" + p.value ,{
                 method:"DELETE",
                 headers : {
                   "Content-Type" : "application/json"
                 }
              }).then(ppp=>{
                  if(ppp.ok)
                  this.nizOsoba[brk].azurirajOsobu("Prazan","krevet","","","","","","");
                  else
                    alert("Doslo je do greske prilikom otpustanja.");
              }).catch(ppp => {
                alert("Greška prilikom otpustanja.");
                             }); 




            }
}


PronadjiOsobu(idd)
{
    for(let i=0;i<this.nizOsoba.length;i++)
    {
       if(this.nizOsoba[i].JMBG===idd)
       return this.nizOsoba[i];
    }
}


}

