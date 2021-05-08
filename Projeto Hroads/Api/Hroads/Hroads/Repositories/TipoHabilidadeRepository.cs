using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();


        public void Create(TipoHabilidade NovoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(NovoTipoHabilidade);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            TipoHabilidade TipoHabilidadeBuscado = ctx.TipoHabilidades.Find(Id);

            ctx.TipoHabilidades.Remove(TipoHabilidadeBuscado);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Read()
        {
            return ctx.TipoHabilidades.ToList();
        }

        public TipoHabilidade ReadById(int Id)
        {
            return ctx.TipoHabilidades.FirstOrDefault(c => c.IdTipoHabilidade == Id);
        }

        public void Update(TipoHabilidade TipoHabilidadeAtualizado, int Id)
        {
            TipoHabilidade TipoHabilidadeBuscado = ctx.TipoHabilidades.Find(Id);

            if(TipoHabilidadeAtualizado.NomeTipoHabilidade != null)
            {
                TipoHabilidadeBuscado.NomeTipoHabilidade = TipoHabilidadeAtualizado.NomeTipoHabilidade;

                ctx.TipoHabilidades.Update(TipoHabilidadeBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
