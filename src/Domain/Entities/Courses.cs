using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Courses : Entity
    {
        public string Name { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                throw new Exception("O nome do curso é inválido");
        }
}
}
