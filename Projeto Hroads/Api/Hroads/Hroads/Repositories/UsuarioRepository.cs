using Hroads.Contexts;
using Hroads.Domains;
using Hroads.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        SENAI_HROADSContext ctx = new SENAI_HROADSContext();

        public void Create(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.Usuarios.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<Usuario> Read()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario ReadById(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == Id);
        }

        public void Update(Usuario UsuarioAtualizado, int Id)
        {
            Usuario UsuarioBuscado = ReadById(Id);
            
            if(UsuarioAtualizado.NomeUsuario != null)
            {
                UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if(UsuarioAtualizado.EmailUsuario != null)
            {
                UsuarioBuscado.EmailUsuario = UsuarioAtualizado.EmailUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if(UsuarioAtualizado.SenhaUsuario != null)
            {
                UsuarioBuscado.SenhaUsuario = UsuarioAtualizado.SenhaUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if(UsuarioAtualizado.IdTipoUsuario != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
