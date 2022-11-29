using Domain.Entities.Base;
using System;

namespace Domain.Entities
{
    public class Certificates : Entity
    {
        public string UserRegistration { get; set; }

        public string FullPath { get; set; }

        public string Description { get; set; }

        public int? Duration { get; set; }
        public void Validate()
        {
            //validar utilizando a api da católica
            //if (this.UserRegistration.)
            //    throw new Exception("O usário informado não existe");

            if( string.IsNullOrWhiteSpace(this.FullPath))
            {
                throw new Exception("O caminho do certificado não pode ser nulo");
            }

            if (string.IsNullOrWhiteSpace(this.Description))
            {
                throw new Exception("A descrição não pode ser nula");
            }
        }

    }
}
