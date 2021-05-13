using Senai.SpMedicalGroup.WebApi.Contexts;
using Senai.SpMedicalGroup.WebApi.Domains;
using Senai.SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();


        public void Create(Especialidade NovaEspecialidade)
        {
            ctx.Especialidades.Add(NovaEspecialidade);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Especialidades.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Especialidade> Read()
        {
            return ctx.Especialidades.ToList();
        }

        public Especialidade ReadById(int Id)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == Id);
        }

        public void Update(int Id, Especialidade EspecialidadeAtualizada)
        {
            Especialidade EspecialidadeBuscada = ReadById(Id);

            if (EspecialidadeAtualizada.NomeEspecialidade != null)
            {
                EspecialidadeBuscada.NomeEspecialidade = EspecialidadeAtualizada.NomeEspecialidade;

                ctx.Especialidades.Update(EspecialidadeBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
