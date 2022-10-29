﻿using Domain.Entities.Base;
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
        [Key]
        public int COURSE_ID { get; set; }

        public string COURSE_NAME { get; set; }

    }
}
