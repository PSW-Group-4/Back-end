using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.EventSourcing;

namespace IntegrationLibrary.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? ModifiedDate { get; protected set; }
        public double Version { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            ModifiedDate = null;
            Version = 1.0;
        }

        public void Modify()
        {
            ModifiedDate = DateTime.Now;
            UpdateVersion();
        }

        public void UpdateVersion()
        {
            Version += 0.1;
        }
    }
}
