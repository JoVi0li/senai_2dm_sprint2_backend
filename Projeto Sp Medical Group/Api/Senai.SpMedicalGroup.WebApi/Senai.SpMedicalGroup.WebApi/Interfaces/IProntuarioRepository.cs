using Senai.SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Interfaces
{
    interface IProntuarioRepository
    {
        void Create(Prontuario NovoProntuario);
        
        List<Prontuario> Read();
        
        Prontuario ReadById(int Id);

        void Update(int Id, Prontuario ProntuarioAtualizado);

        void Delete(int Id);
    }
}
