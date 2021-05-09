using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();


        public void Create(Habilidade NovoHabilidade)
        {
            ctx.Habilidades.Add(NovoHabilidade);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Habilidades.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Habilidade> Read()
        {
            return ctx.Habilidades.ToList();
        }

        public Habilidade ReadById(int Id)
        {
            return ctx.Habilidades.FirstOrDefault(c => c.IdHabilidade == Id);
        }

        public void Update(Habilidade HabilidadeAtualizado, int Id)
        {
            Habilidade HabilidadeBuscada = ReadById(Id);

            if(HabilidadeBuscada.NomeHabilidade != null)
            {
                HabilidadeBuscada.NomeHabilidade = HabilidadeAtualizado.NomeHabilidade;

                ctx.Habilidades.Update(HabilidadeBuscada);

                ctx.SaveChanges();
            }

            if(HabilidadeBuscada.IdTipoHabilidade != null)
            {
                HabilidadeBuscada.IdTipoHabilidade = HabilidadeAtualizado.IdTipoHabilidade;

                ctx.Habilidades.Update(HabilidadeBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
