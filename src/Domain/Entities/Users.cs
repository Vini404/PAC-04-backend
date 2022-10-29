using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : Entity
    {

        public string USER_REGISTRATION { get; set; }

        public string USER_NAME { get; set; }

        public string USER_EMAIL { get; set; }

        public int? CLASS_ID { get; set; }

    }
}
