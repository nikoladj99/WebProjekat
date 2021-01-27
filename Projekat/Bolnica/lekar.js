export class Lekar
{
     constructor(Ime,Prezime,Specijalizacija,IDLekara)
     {
        this.Ime=Ime;
        this.Prezime=Prezime;
        this.Specijalizacija=Specijalizacija;
        this.IDLekara=IDLekara;
     }
     vratiSpecijalizaciju()
     {
         return this.Specijalizacija;
     }
}