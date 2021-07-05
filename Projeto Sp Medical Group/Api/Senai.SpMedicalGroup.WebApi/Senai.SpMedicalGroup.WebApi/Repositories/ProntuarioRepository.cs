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
    public class ProntuarioRepository : IProntuarioRepository
    {
        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();


        public void Create(Prontuario NovoProntuario)
        {
            ctx.Prontuarios.Add(NovoProntuario);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Prontuarios.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Prontuario> Read()
        {
            return ctx.Prontuarios
                .Include(p => p.Consulta)
                .Include(p => p.IdUsuarioNavigation)
                .ToList();
        }

        public Prontuario ReadById(int Id)
        {
            return ctx.Prontuarios.FirstOrDefault(p => p.IdProntuario == Id);
        }

        public void Update(int Id, Prontuario ProntuarioAtualizado)
        {
            Prontuario ProntuarioBuscado = ReadById(Id);

            if (ProntuarioAtualizado.IdUsuario != null)
            {
                ProntuarioBuscado.IdUsuario = ProntuarioAtualizado.IdUsuario;

                ctx.Prontuarios.Update(ProntuarioBuscado);

                ctx.SaveChanges();
            }

            if (ProntuarioAtualizado.Nome != null)
            {
                ProntuarioBuscado.Nome = ProntuarioAtualizado.Nome;

                ctx.Prontuarios.Update(ProntuarioBuscado);

                ctx.SaveChanges();
            }

            if (ProntuarioAtualizado.Telefone != null)
            {
                ProntuarioBuscado.Telefone = ProntuarioAtualizado.Telefone;

                ctx.Prontuarios.Update(ProntuarioBuscado);

                ctx.SaveChanges();
            }

            if (ProntuarioAtualizado.Rg != null)
            {
                ProntuarioBuscado.Rg = ProntuarioAtualizado.Rg;

                ctx.Prontuarios.Update(ProntuarioBuscado);

                ctx.SaveChanges();
            }

            if (ProntuarioAtualizado.Cpf != null)
            {
                ProntuarioBuscado.Cpf = ProntuarioAtualizado.Cpf;
                
                ctx.Prontuarios.Update(ProntuarioBuscado);
                
                ctx.SaveChanges();
            }

            if (ProntuarioAtualizado.Endereco != null)
            {
                ProntuarioBuscado.Endereco = ProntuarioAtualizado.Endereco;
                
                ctx.Prontuarios.Update(ProntuarioBuscado);
                
                ctx.SaveChanges();
            }

            if (ProntuarioAtualizado.DataNascimento != null)
            {
                ProntuarioBuscado.DataNascimento = ProntuarioAtualizado.DataNascimento;
                
                ctx.Prontuarios.Update(ProntuarioBuscado);
                
                ctx.SaveChanges();
            }
        }
    }
}
