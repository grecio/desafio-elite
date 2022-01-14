using System;

namespace Api.Models
{
    public class CompanyModel : ModelBase
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoMunicipal { get; set; }
        public DateTime DataInclusao { get; set; }
        public EStatusCompany StatusEmpresa { get; set; }
        public string ResponsavelLegal { get; set; }
        public string Email { get; set; }
        public string TelefoneContato { get; set; }
    }
}
