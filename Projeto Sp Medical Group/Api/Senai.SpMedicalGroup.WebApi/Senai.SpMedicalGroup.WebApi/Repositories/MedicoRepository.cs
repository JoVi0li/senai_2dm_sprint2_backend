using Microsoft.EntityFrameworkCore;
using Senai.SpMedicalGroup.WebApi.Contexts;
using Senai.SpMedicalGroup.WebApi.Domains;
using Senai.SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();


        public void Create(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Medicos.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Medico> Read()
        {
            return ctx.Medicos.ToList();
        }

        public Medico ReadById(int Id)
        {
            return (Medico)ctx.Medicos
                .Include(
                    m => m.Consulta
                    .Where(c => c.IdMedico == Id)
                );
        }

        public void Update(int Id, Medico MedicoAtualizado)
        {
            Medico MedicoBuscado = ReadById(Id);

            if (MedicoAtualizado.IdEspecialidade != null)
            {
                MedicoBuscado.IdEspecialidade = MedicoAtualizado.IdEspecialidade;

                ctx.Medicos.Update(MedicoBuscado);

                ctx.SaveChanges();
            }

            if (MedicoAtualizado.Nome != null)
            {
                MedicoBuscado.Nome = MedicoAtualizado.Nome;

                ctx.Medicos.Update(MedicoBuscado);

                ctx.SaveChanges();
            }

            if (MedicoAtualizado.Crm != null)
            {
                MedicoBuscado.Crm = MedicoAtualizado.Crm;

                ctx.Medicos.Update(MedicoBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
