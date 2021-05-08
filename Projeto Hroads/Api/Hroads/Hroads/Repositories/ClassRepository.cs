using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class ClassRepository : IClassRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();


        public void Create(Class NovoClass)
        {
            ctx.Classes.Add(NovoClass);

            ctx.SaveChanges();
        }


        public void Delete(int Id)
        {
            Class ClassBuscada = ctx.Classes.Find(Id);

            ctx.Classes.Remove(ClassBuscada);

            ctx.SaveChanges();
        }


        public List<Class> Read()
        {
            return ctx.Classes.ToList();
        }


        public Class ReadById(int Id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == Id);
        }


        public void Update(Class ClassAtualizado, int Id)
        {
            Class ClassBuscada = ctx.Classes.Find(Id);

            if(ClassAtualizado.NomeClasse != null)
            {
                ClassBuscada.NomeClasse = ClassAtualizado.NomeClasse;
                
                ctx.Classes.Update(ClassBuscada);

                ctx.SaveChanges();
            };

        }
    }
}
