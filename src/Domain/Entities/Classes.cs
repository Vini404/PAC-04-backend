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
        [Key]
        public int CLASS_ID { get; set; }

        public int? CLASS_FASE { get; set; }

        public int? COURSE_ID { get; set; }

        public void Validate()
        {
            if (CLASS_FASE <= 0)
                throw new Exception("A fase escolhida é inválida");
        }

    }
}
