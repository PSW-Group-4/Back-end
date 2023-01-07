using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HospitalLibrary.Renovation.Model
{
    public class RenovationAppointment : Appointment
    {
        public enum TypeOfRenovation { Merge, Split }

        public TypeOfRenovation Type {get; private set;}
        
        private IEnumerable<RoomRenovationPlan> _RoomRenovationPlans {get; set;}
        public IEnumerable<RoomRenovationPlan> RoomRenovationPlans {
            get { return new List<RoomRenovationPlan>(_RoomRenovationPlans); }
            private set {_RoomRenovationPlans = value;}
        }

        public RenovationAppointment() {}

        public RenovationAppointment(TypeOfRenovation type, IEnumerable<RoomRenovationPlan> plans, DateRange dateRange, Guid RoomId) : base(Guid.NewGuid(), dateRange, RoomId, null) {
            this.Type = type;
            this.RoomRenovationPlans = plans.ToList();
            Validate();
        }

        public RenovationAppointment(RenovationSessionAggregateRoot root, Guid roomId) : base(Guid.NewGuid(), new DateRange(root.Start.Value, root.End.Value), roomId, null){
            this.RoomRenovationPlans = root.RoomRenovationPlans.ToList();
            this.Type = root.TypeOfRenovation.Value;
            Validate();
        }

        private void Validate() {
            ValidateListLength();
            ValidateListEntries();
        }

        public IEnumerable<RoomRenovationPlan> GetNewRoomPlans() {
            return from plan in RoomRenovationPlans where plan.Type == RoomRenovationPlan.TypeOfPlan.New select plan;
        }

        public IEnumerable<RoomRenovationPlan> GetOldRoomPlans() {
            return from plan in RoomRenovationPlans where plan.Type == RoomRenovationPlan.TypeOfPlan.Old select plan;
        }

        public IEnumerable<RoomRenovationPlan> GetAllPlans() {
            return new List<RoomRenovationPlan>(RoomRenovationPlans);
        }

        private void ValidateListLength() {
            if(this.RoomRenovationPlans.ToList().Count != 3) {
                throw new InvalidValueException();
            }
        }

        private void ValidateListEntries() {
            foreach (RoomRenovationPlan plan in this.RoomRenovationPlans) {
                plan.Validate();
            }
        }

        public bool ShouldBeFinished() {
            return false == this.IsDone && DateRange.IsLesserThan(DateTime.Now);
        }

        public void Finish() {
            this.FinishAppointment();
            this.DiscardRoom();
        }

        public bool IsPrimaryRenovationAppointment() {
            if(this.RoomId.Equals(this.RoomRenovationPlans.First().Id)) {
                return true;
            }
            return false;
        }

    }
}