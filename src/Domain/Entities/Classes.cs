using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Classes : Entity
    {
        public int Fase { get; set; }

        public int CourseID { get; set; }

        public void Validate()
        {
            if (this.CourseID <= 0)
                throw new Exception("A fase escolhida é inválida");
        }

    }
}
