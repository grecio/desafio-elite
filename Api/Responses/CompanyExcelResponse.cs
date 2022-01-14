using System;

namespace Api.Responses
{
    public class CompanyExcelResponse
    {
        public int Codigo { get; set; }
        public string Cnpj { get; set; }
        public string Razao { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string NomeResponsavel { get; set; }
        public string DataInclusao { get; set; }
    }
}
