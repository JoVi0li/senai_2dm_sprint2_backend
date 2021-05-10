using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);

        void Create(Usuario NovoUsuario);
        
        List<Usuario> Read();
        
        Usuario ReadById(int Id);

        void Update(Usuario UsuarioAtualizado, int Id);

        void Delete(int Id);
    }
}
