using Api.Models;
using System;

namespace Api.Responses
{
    public class CompanyResponse
    {
        public string Cnpj { get; set; }
        public string Razao { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EStatusCompany Status { get; set; }
        public DateTime DataInclusao { get; set; }

    }
}
