using System;

namespace Api.Requests
{
    public class CompanyFilterRequest
    {
        public int Status { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

    }
}
