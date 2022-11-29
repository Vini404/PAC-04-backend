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
        public string Registration { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int ClassID { get; set; }

    }
}
