using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CertificatesRepository : Repository<Certificates>
    {
        public CertificatesRepository(DataContext context) : base(context)
        {

        }
        public List<Certificates> GetAllCertificates()
        {
            var certificates = base.Get().ToList();
            return certificates;
        }
        public Certificates GetById(int id)
        {
            var certificate = GetByIdAsync(id).GetAwaiter().GetResult();
            return certificate;
        }
        public List<Certificates> GetByUser(string userRegistration)
        {
            var certificates = base.Get().Where(r => r.UserRegistration == userRegistration).ToList();
            return certificates;
        }
        public void Insert(Certificates entity)
        {
            Insert(entity);
            SaveChangesAsync();
        }

    }
}
