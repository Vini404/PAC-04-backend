using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CoursesRepository : Repository<Courses>
    {
        public CoursesRepository(DataContext context) : base(context)
        {
        }

        public Courses GetById(int id)
        {
            var courses = GetByIdAsync(id).GetAwaiter().GetResult();
            return courses;
        }
    }
}
