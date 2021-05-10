using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IProntuarioRepository
    {
        void Create(Prontuario NovoProntuario);
        
        List<Prontuario> Read();
        
        Prontuario ReadById(int Id);

        void Update(Prontuario ProntuarioAtualizado, int Id);

        void Delete(int Id);
    }
}
