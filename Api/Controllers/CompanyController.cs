using Api.Requests;
using Api.Responses;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;

            _companyService.Iniciar();
        }

        [HttpGet]
        public List<CompanyResponse> Get([FromQuery] CompanyFilterRequest request)
        {
            return _companyService.Listar(request);
        }

        [HttpGet]
        [Route("Exportar")]
        public async Task<ActionResult> DownloadFile()
        {
            var stream = _companyService.Exportar();
            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bytes = ms.ToArray();
            }

            return await Task.FromResult(File(bytes, "application/octet-stream", fileDownloadName: "companias-exportadas.csv"));
        }
    }
}
