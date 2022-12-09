using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Renovation.Model
{
    public class RenovationAppointment : Appointment
    {
        public enum TypeOfRenovation { Merge, Split }

        public TypeOfRenovation Type {get; private set;}
        public IEnumerable<RoomRenovationPlan> RoomRenovationPlans {
            get { return new List<RoomRenovationPlan>(RoomRenovationPlans); }
            private set { RoomRenovationPlans = value; }
        }

        public RenovationAppointment() {}

        public RenovationAppointment(TypeOfRenovation type, IEnumerable<RoomRenovationPlan> plans, DateRange dateRange) {
            this.Type = type;
            this.RoomRenovationPlans = plans;
            this.DateRange = dateRange;
            Validate();
        }

        private void Validate() {
            ValidateListLength();
        }

        public IEnumerable<RoomRenovationPlan> GetNewRoomPlans() {
            return from plan in RoomRenovationPlans where plan.Type == RoomRenovationPlan.TypeOfPlan.New select plan;
        }

        public IEnumerable<RoomRenovationPlan> GetOldRoomPlans() {
            return from plan in RoomRenovationPlans where plan.Type == RoomRenovationPlan.TypeOfPlan.Old select plan;
        }

        private void ValidateListLength() {
            if(this.RoomRenovationPlans.ToList().Count != 3) {
                throw new InvalidValueException();
            }
        }

    }
}