using Senai.SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        void Create(Clinica NovaClinica);

        List<Clinica> Read();

        Clinica ReadById(int Id);

        void Update(int Id, Clinica ClinicaAtualizada);

        void Delete(int Id);
    }
}
