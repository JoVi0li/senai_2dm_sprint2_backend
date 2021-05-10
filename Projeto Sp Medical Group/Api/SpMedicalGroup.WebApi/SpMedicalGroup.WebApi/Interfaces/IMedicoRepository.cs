using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        void Create(Medico NovoMedico);

        List<Medico> Read(); 

        Medico ReadById(int Id);

        void Update(Medico MedicoAtualizado, int Id);

        void Delete(int Id);
    }
}
