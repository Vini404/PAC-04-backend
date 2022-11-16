using Domain.Entities.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interactions : Entity
    {
        public DateTime Datetime { get; set; }

        public InterectionType InteractionType { get; set; }

        public int CertificateID { get; set; }

        public string Description { get; set; }

    }
}
