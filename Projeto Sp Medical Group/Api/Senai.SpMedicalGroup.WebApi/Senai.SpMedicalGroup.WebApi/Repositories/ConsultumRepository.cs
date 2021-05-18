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
    public class ConsultumRepository : IConsultumRepository
    {
        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();


        public void Create(Consultum NovaConsultum)
        {
            ctx.Consulta.Add(NovaConsultum);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Consulta.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Consultum> Read()
        {
            return ctx.Consulta.ToList();
        }

        public Consultum ReadById(int Id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == Id);
        }

        public List<Consultum> ReadByIdDoctor(int Id)
        {
            return ctx.Consulta
                .Include(c => c.IdMedicoNavigation)
                .Select(c => new Consultum() { 
                    IdConsulta = c.IdConsulta,
                    IdProntuario = c.IdProntuario,
                    IdMedico = c.IdMedico,
                    DataConsulta = c.DataConsulta,
                    Situacao = c.Situacao,
                    IdMedicoNavigation = new Medico()
                    {
                        Nome = c.IdMedicoNavigation.Nome,
                        Crm = c.IdMedicoNavigation.Crm,
                        IdMedico = (int)c.IdMedico,
                        IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        IdClinica = c.IdMedicoNavigation.IdClinica
                    }
                })
                .Where(c => c.IdMedico == Id)
                .ToList();
        }

        public List<Consultum> ReadByIdPatient(int Id)
        {
            return ctx.Consulta
                .Include(c => c.IdProntuarioNavigation)
                .Select(c => new Consultum()
                {
                    IdConsulta = c.IdConsulta,
                    IdProntuario = c.IdProntuario,
                    IdMedico = c.IdMedico,
                    DataConsulta = c.DataConsulta,
                    Situacao = c.Situacao,
                    IdProntuarioNavigation = new Prontuario()
                    {
                        IdProntuario = (int)c.IdProntuario,
                        IdUsuario = c.IdProntuarioNavigation.IdUsuario,
                        Nome = c.IdProntuarioNavigation.Nome,
                        Telefone = c.IdProntuarioNavigation.Telefone,
                        Rg = c.IdProntuarioNavigation.Rg,
                        Cpf = c.IdProntuarioNavigation.Cpf,
                        Endereco = c.IdProntuarioNavigation.Endereco,
                        DataNascimento = c.IdProntuarioNavigation.DataNascimento
                    }
                })
                .Where(c => c.IdProntuarioNavigation.IdUsuario == Id)
                .ToList();
        }

        public void Update(int Id, Consultum ConsultumAtualizado)
        {
            Consultum ConsultumBuscada = ReadById(Id);

            if (ConsultumAtualizado.IdProntuario != null)
            {
                ConsultumBuscada.IdProntuario = ConsultumAtualizado.IdProntuario;

                ctx.Consulta.Update(ConsultumBuscada);

                ctx.SaveChanges();
            }

            if (ConsultumAtualizado.IdMedico != null)
            {
                ConsultumBuscada.IdMedico = ConsultumAtualizado.IdMedico;

                ctx.Consulta.Update(ConsultumBuscada);

                ctx.SaveChanges();
            }

            if (ConsultumAtualizado.DataConsulta != null)
            {
                ConsultumBuscada.DataConsulta = ConsultumAtualizado.DataConsulta;

                ctx.Consulta.Update(ConsultumBuscada);

                ctx.SaveChanges();
            }

            if (ConsultumAtualizado.Situacao != null)
            {
                ConsultumBuscada.Situacao = ConsultumAtualizado.Situacao;

                ctx.Consulta.Update(ConsultumBuscada);

                ctx.SaveChanges();
            }

            if (ConsultumAtualizado.Descricao != null)
            {
                ConsultumBuscada.Descricao = ConsultumAtualizado.Descricao;

                ctx.Consulta.Update(ConsultumBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
