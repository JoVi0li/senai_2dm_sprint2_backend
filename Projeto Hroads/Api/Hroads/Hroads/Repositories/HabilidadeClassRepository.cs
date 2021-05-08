using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class HabilidadeClassRepository : IHabilidadeClassRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();


        public void Create(HabilidadeClass NovoHabilidadeClass)
        {
            ctx.HabilidadeClasses.Add(NovoHabilidadeClass);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            HabilidadeClass HabilidadeClassBuscada = ctx.HabilidadeClasses.Find(Id);

            ctx.Remove(HabilidadeClassBuscada);

            ctx.SaveChanges();
        }

        public List<HabilidadeClass> Read()
        {
            return ctx.HabilidadeClasses.ToList();
        }

        public HabilidadeClass ReadById(int Id)
        {
            return ctx.HabilidadeClasses.FirstOrDefault(c => c.IdHabilidadeClasses == Id);
        }

        public void Update(HabilidadeClass HabilidadeClassAtualizado, int Id)
        {
            HabilidadeClass HabilidadeClassBuscada = ctx.HabilidadeClasses.Find(Id);
            
            if(HabilidadeClassAtualizado.IdClasse != null)
            {
                HabilidadeClassBuscada.IdClasse = HabilidadeClassAtualizado.IdClasse;
                
                ctx.HabilidadeClasses.Update(HabilidadeClassBuscada);

                ctx.SaveChanges();
            }

            if(HabilidadeClassAtualizado.IdHabilidade != null)
            {
                HabilidadeClassBuscada.IdHabilidade = HabilidadeClassAtualizado.IdHabilidade;

                ctx.HabilidadeClasses.Update(HabilidadeClassBuscada);

                ctx.SaveChanges();
            }
        }


    }
}
