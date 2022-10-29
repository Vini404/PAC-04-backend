using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Certificates : Entity
    {
        [Key]
        public int CERTIFICATE_ID { get; set; }

        public string USER_REGISTRATION { get; set; }

        public string CERTIFICATE_FULL_PATH { get; set; }

        public string CERTIFICATE_DESCRIPTION { get; set; }

        public int? CERTIFICATE_DURATION { get; set; }

    }
}
