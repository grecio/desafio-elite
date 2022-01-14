using Api.Requests;
using Api.Responses;
using System.Collections.Generic;
using System.IO;

namespace Api.Services.Interfaces
{
    public interface ICompanyService
    {
        void Iniciar();
        List<CompanyResponse> Listar(CompanyFilterRequest request);
        Stream Exportar();
    }
}
