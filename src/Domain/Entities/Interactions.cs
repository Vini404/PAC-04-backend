using Domain.Entities.Base;
using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Interactions : Entity
    {
        public DateTime Datetime { get; set; }

        public InteractionType InteractionType { get; set; }

        public int CertificateID { get; set; }

        public string Description { get; set; }

    }
}
