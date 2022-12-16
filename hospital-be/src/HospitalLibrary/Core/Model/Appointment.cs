using System;
using HospitalLibrary.RoomsAndEqipment.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationLibrary.Exceptions;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public Guid Id {get; set;}
        public DateRange DateRange { get; private set; }
        public Guid? RoomId { get; protected set; }
        public String Discriminator {get; private set;}
        public virtual Room Room { get; private set; }
        public bool IsDone { get; private set; }
        
        public  Appointment(){}

        public Appointment(Guid id, DateRange dateRange, Guid? roomId, Room room)
        {
            Id = id;
            DateRange = dateRange;
            RoomId = roomId;
            Room = room;
            IsDone = false;
            Validate();
        }

        public void FinishAppointment()
        {
            IsDone = true;
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty))
            {
                throw new ValueObjectValidationFailedException();
            }

            if (DateRange == null)
            {
                throw new ValueObjectValidationFailedException();
            }
        }

        public void DiscardRoom()
        {
            this.Room = null;
            this.RoomId = (Guid?)null;
        }

        public void Update(Appointment schedule)
        {
            IsDone = schedule.IsDone;
            DateRange = schedule.DateRange;
        }
    }
}