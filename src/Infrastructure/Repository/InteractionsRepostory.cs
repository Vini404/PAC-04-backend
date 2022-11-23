﻿using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualBasic;
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

        public void Insert(Photos entity)
        {
            Insert(entity);
            SaveChangesAsync();
        }
    }
}
