using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PhotosRepository : Repository<Photos>
    {
        public PhotosRepository(DataContext context) : base(context)
        {
        }

        public Photos GetById(int id)
        {
            return GetById(id);
        }

        public Photos GetByUser(string userRegistration)
        {
            return base.Get().Where(r => r.UserRegistration == userRegistration).FirstOrDefault();
        }

        public void Insert(Photos entity)
        {
            Insert(entity);
            SaveChangesAsync();
        }
    }
}
