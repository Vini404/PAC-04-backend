using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class InteractionsRepository : Repository<Interactions>
    {
        public InteractionsRepository(DataContext context) : base(context)
        {
        }

        public Interactions GetById(int id)
        {
            return GetById(id);
        }

        public List<Interactions> GetByCertificate(int certificateId)
        {
            return base.Get().Where(r => r.CertificateID == certificateId).ToList();
        }

        public InteractionType GetCertificateStatus(int certificateId)
        {
            var dataRegistroMaisRecente = base.Get().Where(r => r.CertificateID == certificateId).Max(f=>f.Datetime);
            return base.Get().Where(r => r.CertificateID == certificateId).Where(f => f.Datetime == dataRegistroMaisRecente).FirstOrDefault().InteractionType;
        }

        public void Insert(Photos entity)
        {
            Insert(entity);
            SaveChangesAsync();
        }
    }
}
