using Senai.SpMedicalGroup.WebApi.Contexts;
using Senai.SpMedicalGroup.WebApi.Domains;
using Senai.SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();

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

        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.Email == Email && c.Senha == Senha);
        }

        public List<Usuario> Read()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario ReadById(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == Id);
        }

        public void Update(int Id, Usuario UsuarioAtualizado)
        {
            Usuario UsuarioBuscado = ReadById(Id);

            if (UsuarioAtualizado.IdTipoUsuario != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.Nome != null)
            {
                UsuarioBuscado.Nome = UsuarioAtualizado.Nome;

                ctx.Usuarios.Update(UsuarioBuscado);

                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.Email != null)
            {
                UsuarioBuscado.Email = UsuarioAtualizado.Email;
                
                ctx.Usuarios.Update(UsuarioBuscado);
                
                ctx.SaveChanges();
            }

            if (UsuarioAtualizado.Senha != null)
            {
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
                
                ctx.Usuarios.Update(UsuarioBuscado);
                
                ctx.SaveChanges();
            }
        }
    }
}
