using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photos : Entity
    {
        public string USER_REGISTRATION { get; set; }

        public string PHOTO_FULL_PATH { get; set; }

    }
}
