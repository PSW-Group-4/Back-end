using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class DoctorRoom : Room
    {
        public void Update(DoctorRoom room)
        {
            base.Update(room);
            RoomsEquipment = room.RoomsEquipment;
        }
    }
}
