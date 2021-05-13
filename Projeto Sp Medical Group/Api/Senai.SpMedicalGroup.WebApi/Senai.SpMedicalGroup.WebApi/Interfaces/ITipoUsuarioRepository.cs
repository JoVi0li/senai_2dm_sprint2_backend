using Senai.SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        void Create(TipoUsuario NovoTipoUsuario);
        
        List<TipoUsuario> Read();
        
        TipoUsuario ReadById(int Id);

        void Update(int Id, TipoUsuario TipoUsuarioAtualizado);

        void Delete(int Id);
    }
}
