using Core;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ClassesRepository : Repository<Classes>
    {

        public ClassesRepository(DataContext context) : base(context)
        {
        }

        public Classes GetById(int id)
        {
            var classe =  GetByIdAsync(id).GetAwaiter().GetResult();
            return classe;
        }

        public void Insert(Classes entity) 
        {
            Insert(entity);
            SaveChangesAsync();
        }
    }
}
