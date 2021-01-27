import {Bolnica} from "./bolnica.js" 


fetch("https://localhost:5001/Bolnica/PreuzmiBolnice").then(p=>{
    p.json().then(data=>{
    data.forEach(element => {
        const bol=new Bolnica(element.ime,element.id,element.n,element.m);
        bol.prikaziBolnicu(document.body);
        element.osobe.forEach((el,ind)=>{
             bol.nizOsoba[el.brojk]
             .azurirajOsobu(el.ime,el.prezime,el.jmbg,el.hitanSlucaj,el.tipOsiguranja,el.tipOdeljenje,el.brojk,el.idLek);
             bol.brZauzetihKreveta++;
        });
        

       
fetch("https://localhost:5001/Bolnica/PreuzmiBolniceSaLekarima").then(p=>{
p.json().then(data=>{
data.forEach(element=>{
     element.lekari.forEach(l=>{
         bol.dodajLekara(l);
     })
})
})
});
       

        console.log(bol.nizLekara);
        console.log(bol.nizOsoba);

       
        
     
    });
});
}
); 








