using System;
using System.Collections.Generic;
using System.Linq;
using Api.Services.Interfaces;
using Api.Responses;
using Api.Models;
using Api.Requests;
using System.IO;
using System.Text;
using Api.Utils;

namespace Api.Services
{
    public class CompanyService : ICompanyService
    {
        private List<CompanyModel> _companyModelList;

        public CompanyService()
        {
            _companyModelList = new List<CompanyModel>();
        }

        public Stream Exportar()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in _companyModelList)
            {
                sb.AppendFormat(
                    "{0};{1};{2};{3};{4};{5};{6}",
                    item.Codigo,
                    FormatCnpjCpf.FormatCNPJ(item.Cnpj),
                    item.RazaoSocial,
                    item.InscricaoMunicipal,
                    item.DataInclusao.ToString("dd-MM-yyyy"),
                    item.ResponsavelLegal,
                    Environment.NewLine);
            }

            var stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(sb.ToString());
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        public void Iniciar()
        {
            _companyModelList.AddRange(new CompanyModel[]
            {
                new CompanyModel() {
                    Cnpj = "06975199000150",
                    Codigo = 1,
                    DataInclusao = new DateTime(2022, 1, 10),
                    Email = "empresa1@gmail.com",
                    InscricaoMunicipal = "200293265",
                    RazaoSocial = "Razao Social Empresa 1",
                    ResponsavelLegal = "Responsavel Legal Empresa 1",
                    StatusEmpresa = EStatusCompany.Ativa,
                    TelefoneContato = "84988010101"
                },
                 new CompanyModel() {
                    Cnpj = "06164253000187",
                    Codigo = 2,
                    DataInclusao = new DateTime(2022, 1, 11),
                    Email = "empresa2@gmail.com",
                    InscricaoMunicipal = "200293266",
                    RazaoSocial = "Razao Social Empresa 2",
                    ResponsavelLegal = "Responsavel Legal Empresa 2",
                    StatusEmpresa = EStatusCompany.Ativa,
                    TelefoneContato = "84988010202"
                },
                new CompanyModel() {
                    Cnpj = "12345678999",
                    Codigo = 3,
                    DataInclusao = new DateTime(2022, 1, 13),
                    Email = "empresa3@gmail.com",
                    InscricaoMunicipal = "200293200",
                    RazaoSocial = "Razao Social Empresa 3",
                    ResponsavelLegal = "Responsavel Legal Empresa 3",
                    StatusEmpresa = EStatusCompany.Inativa,
                    TelefoneContato = "84988010303"
                },
            });
        }

        public List<CompanyResponse> Listar(CompanyFilterRequest request)
        {
            if (request.Status > 0)
            {
                _companyModelList = _companyModelList.Where(item => item.StatusEmpresa == (EStatusCompany)request.Status).ToList();
            }

            if (request.DataInicial != null && request.DataFinal == null)
            {
                _companyModelList = _companyModelList.Where(item => item.DataInclusao >= request.DataInicial).ToList();
            }
            else if (request.DataInicial == null && request.DataFinal != null)
            {
                _companyModelList = _companyModelList.Where(item => item.DataInclusao <= request.DataFinal).ToList();
            }
            else if (request.DataInicial != null && request.DataFinal != null)
            {
                _companyModelList = _companyModelList.Where(item => item.DataInclusao >= request.DataInicial && item.DataInclusao <= request.DataFinal).ToList();
            }

            return _companyModelList
            .Select(item => new CompanyResponse()
            {
                Cnpj = item.Cnpj,
                Email = item.Email,
                Razao = item.RazaoSocial,
                Responsavel = item.ResponsavelLegal,
                Telefone = item.TelefoneContato,
                Status = item.StatusEmpresa,
                DataInclusao = item.DataInclusao
            }).ToList();
        }
    }
}
