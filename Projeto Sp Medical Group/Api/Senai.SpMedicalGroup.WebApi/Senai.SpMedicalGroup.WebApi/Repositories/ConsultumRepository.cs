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
            return ctx.Consulta
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdProntuarioNavigation)
                .Select(c => new Consultum()
                {
                    IdConsulta = c.IdConsulta,
                    Situacao = c.Situacao,
                    DataConsulta = c.DataConsulta,
                    IdMedicoNavigation = new Medico()
                    {
                        Nome = c.IdMedicoNavigation.Nome
                    },
                    IdProntuarioNavigation = new Prontuario()
                    {
                        Nome = c.IdProntuarioNavigation.Nome
                    }
                })
                .ToList();
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
                        IdMedico = (int)c.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario
                    },
                    IdProntuarioNavigation = new Prontuario()
                    {
                        Nome = c.IdProntuarioNavigation.Nome
                    }
                    
                })
                .Where(c => c.IdMedicoNavigation.IdUsuario == Id)
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
                    },
                    IdMedicoNavigation = new Medico()
                    {
                        Nome = c.IdMedicoNavigation.Nome
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
