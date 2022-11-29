using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void CreateInteractionAproved(int certificateId)
        {
            var interaction = new Interactions 
            { 
                CertificateID = certificateId, 
                Datetime = DateTime.Now, 
                Description = string.Empty, 
                InteractionType = InteractionType.Aprovado 
            };
            base.Add(interaction);
            base.SaveChangesAsync();
        }

        public void CreateInteractionReproved(int certificateId, string motivoReprovacao)
        {
            var interaction = new Interactions
            {
                CertificateID = certificateId,
                Datetime = DateTime.Now,
                Description = motivoReprovacao,
                InteractionType = InteractionType.Reprovado
            };

            base.Add(interaction);
            base.SaveChangesAsync();
        }

        public void CreateInteractionAltered(int certificateId, string descricaoAltercao)
        {
            var interaction = new Interactions
            {
                CertificateID = certificateId,
                Datetime = DateTime.Now,
                Description = descricaoAltercao,
                InteractionType = InteractionType.Alterado
            };

            base.Add(interaction);
            base.SaveChangesAsync();
        }

        public void CreateInteractionClosed(int certificateId)
        {
            var interaction = new Interactions
            {
                CertificateID = certificateId,
                Datetime = DateTime.Now,
                Description = string.Empty,
                InteractionType = InteractionType.Fechado
            };

            base.Add(interaction);
            base.SaveChangesAsync();
        }

        public InteractionType GetCertificateStatus(int certificateId)
        {
            var dataRegistroMaisRecente = base.Get().Where(r => r.CertificateID == certificateId).Max(f=>f.Datetime);
            return base.Get().Where(r => r.CertificateID == certificateId).Where(f => f.Datetime == dataRegistroMaisRecente).FirstOrDefault().InteractionType;
        }

        public List<Interactions> GetCertificateHistory(int certificateId)
        {
            var interactionsList = base.Get().Where(r => r.CertificateID == certificateId).OrderByDescending(r => r.Datetime).ToList();
            return interactionsList;
        }

        public void Insert(Interactions entity)
        {
            Insert(entity);
            SaveChangesAsync();
        }
    }
}
