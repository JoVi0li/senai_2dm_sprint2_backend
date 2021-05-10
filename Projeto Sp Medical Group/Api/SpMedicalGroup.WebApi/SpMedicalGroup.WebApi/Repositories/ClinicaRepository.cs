using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();

        public void Create(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Clinicas.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Clinica> Read()
        {
            return ctx.Clinicas.ToList();
        }

        public Clinica ReadById(int Id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == Id);
        }

        public void Update(Clinica ClinicaAtualizada, int Id)
        {
            Clinica ClinicaBuscada = ReadById(Id);

            if(ClinicaAtualizada.RazaoSocial!= null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }
            if (ClinicaAtualizada.NomeFantasia!= null)
            {
                ClinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }

            if (ClinicaAtualizada.Cnpj!= null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }

            if (ClinicaAtualizada.Endereco != null)
            {
                ClinicaBuscada.Endereco = ClinicaAtualizada.Endereco;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }

            if (ClinicaAtualizada.HorarioFuncionamento != null)
            {
                ClinicaBuscada.HorarioFuncionamento = ClinicaAtualizada.HorarioFuncionamento;

                ctx.Clinicas.Update(ClinicaBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
