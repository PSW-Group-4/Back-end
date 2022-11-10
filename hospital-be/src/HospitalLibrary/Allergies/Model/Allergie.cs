using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Allergies.Model
{
    public class Allergie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        internal void Update(Allergie allergie)
        {
            Name = allergie.Name;
        }
    }
}
