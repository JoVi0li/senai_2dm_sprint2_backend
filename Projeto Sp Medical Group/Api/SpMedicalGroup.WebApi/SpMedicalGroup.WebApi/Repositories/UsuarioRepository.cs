using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();

        public void Create(Usuario NovoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string Email, string Senha)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Read()
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email

                })
                .ToList();
        }

        public Usuario ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario UsuarioAtualizado, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
