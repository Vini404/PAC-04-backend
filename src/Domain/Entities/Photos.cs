using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photos : Entity
    {
        public string UserRegistration { get; set; }

        public string FullPath { get; set; }

        public void Validate()
        {
            //validar utilizando a api da católica
            //if (this.UserRegistration.)
            //    throw new Exception("O usário informado não existe");

            if (string.IsNullOrWhiteSpace(this.FullPath))
            {
                throw new Exception("O caminho da foto de perfil não pode ser nulo");
            }
        }
    }
}
