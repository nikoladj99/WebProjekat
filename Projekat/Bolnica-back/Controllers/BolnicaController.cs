using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bolnica_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Bolnica_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BolnicaController : ControllerBase
    {
        
        public BolnicaContext Context{get;set;}


        public BolnicaController(BolnicaContext context)
        {
             Context = context;
        }

       [Route("PreuzmiBolnice")]
       [HttpGet]
       public async Task<List<Bolnica>> PreuzmiBolnice()
       {
           return await Context.Bolnice.Include(p=>p.Osobe).ToListAsync();
       }

       [Route("PreuzmiBolniceSaLekarima")]
       [HttpGet]
       public async Task<List<Bolnica>> PreuzmiBolniceSaLekarima()
       {
           return await Context.Bolnice.Include(p=>p.Lekari).ToListAsync();
       }

       [Route("UpisiUBolnicu")]
       [HttpPost]
       public async Task UpisiUBolnicu([FromBody] Bolnica bolnica)
       {
           Context.Bolnice.Add(bolnica);
           await Context.SaveChangesAsync();
       }

       [Route("AzurirajBolnicu")]
       [HttpPut]
       public async Task AzurirajBolnicu([FromBody] Bolnica bolnica)
       {
           Context.Update<Bolnica>(bolnica);
           await Context.SaveChangesAsync();
       }

       [Route("IzbrisiBolnicu/{ID}")]
       [HttpDelete]
       public async Task IzbrisiBolnicu(int ID)
      {
          var bolnica=await Context.Bolnice.FindAsync(ID);
          Context.Remove(bolnica);
          await Context.SaveChangesAsync();
      }

       [Route("UpisiOsobu/{IDB}")] 
       [HttpPost]
       public async Task UpisiOdeljene(int IDB,[FromBody] Osoba osoba)
       {
            var bol=await Context.Bolnice.FindAsync(IDB);
            osoba.Bolnica=bol;
            Context.Osobe.Add(osoba);
            await Context.SaveChangesAsync();
       }

       [Route("IzbrisiOsobu/{Jmbg}")]
       [HttpDelete]
       public async Task IzbrisiOdeljenje(string Jmbg)
      {
          var osoba=await Context.Osobe.FindAsync(Jmbg);
          Context.Remove(osoba);
          await Context.SaveChangesAsync();
      }

     
       [Route("UpisiLekara/{IDB}")] 
       [HttpPost]
       public async Task UpisiLekara(int IDB,[FromBody] Lekar lekar)
       {
            var bol=await Context.Bolnice.FindAsync(IDB);
            lekar.Bolnica=bol;
            Context.Lekari.Add(lekar);
            await Context.SaveChangesAsync();
       }

       [Route("IzbrisiLekara/{ID}")]
       [HttpDelete]
       public async Task IzbrisiLekara(string id)
      {
          var lekar=await Context.Lekari.FindAsync(id);
          Context.Remove(lekar);
          await Context.SaveChangesAsync();
      }
      

    }
}
