using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Certificates
{
    public class ReproveCertificateRequest
    {
        public int CertificateId { get; set; }
        public string Description { get; set; }
    }
}
