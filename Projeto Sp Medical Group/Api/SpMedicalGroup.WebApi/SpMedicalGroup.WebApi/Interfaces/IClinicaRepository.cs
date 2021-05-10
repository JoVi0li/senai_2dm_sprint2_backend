using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        void Create(Clinica NovaClinica);

        List<Clinica> Read();

        Clinica ReadById(int Id);

        void Update(Clinica ClinicaAtualizada, int Id);

        void Delete(int Id);
    }
}
