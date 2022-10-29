using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PhotosRepositorys : Repository<Photos>
    {
        public PhotosRepositorys(DataContext context) : base(context)
        {
        }

        public Photos GetById(int id)
        {
            return GetById(id);
        }

        public void Insert(Photos entity)
        {
            Insert(entity);
            SaveChangesAsync();
        }
    }
}
