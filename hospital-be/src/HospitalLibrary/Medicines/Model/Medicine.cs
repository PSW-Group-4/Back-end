using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Medicines.Model
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public void Update(Medicine medicine)
        {
            Name = medicine.Name;
        }
    }
}
