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
        public string UserRegistration { get; set; }

        public string FullPath { get; set; }

        public string Description { get; set; }

        public int? Duration { get; set; }

    }
}
