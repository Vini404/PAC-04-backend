using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Certificates
{
    public class AlterCertificateRequest
    {
        public int id { get; set; }
        public string FullPath { get; set; }

        public string Description { get; set; }

        public int? Duration { get; set; }
    }
}
