using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? ModifiedDate { get; protected set; }
        public double Version { get; protected set; }

        public void Modify()
        {
            ModifiedDate = DateTime.Now;
        }

        public void UpdateVersion()
        {
            Version += 0.1;
        }
    }
}
