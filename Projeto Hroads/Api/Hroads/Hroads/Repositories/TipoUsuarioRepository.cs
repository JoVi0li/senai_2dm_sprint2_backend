﻿using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();


        public void Create(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);

            ctx.SaveChanges();

        }

        public void Delete(int Id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(Id);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Read()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario ReadById(int Id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == Id);
        }

        public void Update(TipoUsuario TipoUsuarioAtualizado, int Id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(Id);

            if(TipoUsuarioAtualizado.Titulo != null)
            {
                TipoUsuarioBuscado.Titulo = TipoUsuarioAtualizado.Titulo;

                ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

                ctx.SaveChanges();
            }
        }
    }
}