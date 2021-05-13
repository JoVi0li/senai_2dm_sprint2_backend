using Senai.SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        void Create(Medico NovoMedico);

        List<Medico> Read();

        Medico ReadById(int Id);

        void Update(int Id, Medico MedicoAtualizado);

        void Delete(int Id);
    }
}
