using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interactions : Entity
    {
        public DateTime INTERACTION_DATETIME { get; set; }

        public int? INTERACTION_TYPE { get; set; }

        public int CERTIFICATE_ID { get; set; }

        public string INTERACTION_DESCRIPTION { get; set; }

    }
}
