using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;

namespace IntegrationLibrary.Tendering.Model
{
    [Table("tenders")]
    public class Tender : AggregateRoot
    {
        private IEnumerable<Blood> _blood;
        public virtual BloodBank Winner { get; private set; }
        public TenderStatus Status { get; private set;  }

        [JsonInclude]
        public IEnumerable<Blood> Blood
        {
            get
            {
                return _blood.ToList();
            }

            private set => _blood = value;
        }
        public DateTime? Deadline { get; private set; }

        public Tender() { }
        private Tender(IEnumerable<Blood> blood, DateTime deadline)
        {
            Id = Guid.NewGuid();
            Blood = blood;
            CreatedDate = DateTime.Now;
            Deadline = deadline;
            Version = 1.0;
            Status = TenderStatus.ACTIVE;
            Winner = null;
        }

        private Tender(IEnumerable<Blood> blood)
        {
            Id = Guid.NewGuid();
            Blood = blood;
            CreatedDate = DateTime.Now;
            Deadline = null;
            Version = 1.0;
            Status = TenderStatus.ACTIVE;
            Winner = null;
        }

        public bool IsActive()
        {
            return Deadline == null || DateTime.Compare(DateTime.Now, (DateTime)Deadline) < 0 || Winner == null;
        }

        public static Tender Create(IEnumerable<Blood> blood, DateTime? deadline)
        {
            if(deadline == null)
            {
                return new Tender(blood);
            }

            if(DateTime.Compare(DateTime.Now, (DateTime)deadline) < 0)
            {
                return new Tender(blood, (DateTime)deadline);
            } else
            {
                throw new DateIsBeforeTodayException();
            }
        }

        public static Tender Create(TenderCreatedEvent tenderCreatedEvent)
        {
            if(tenderCreatedEvent.Deadline == null)
            {
                return new Tender(tenderCreatedEvent.Blood);
            }
            if(DateTime.Compare(DateTime.Now, (DateTime)tenderCreatedEvent.Deadline) < 0)
            {
                return new Tender(tenderCreatedEvent.Blood, (DateTime)tenderCreatedEvent.Deadline);
            } else
            {
                throw new DateIsBeforeTodayException();
            }
        }

        private void AddEvent(DomainEvent @event)
        {
        }
        public void Causes(DomainEvent @event)
        {
            Apply(@event);
            AddEvent(@event);
        }
        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Modify();
        }
        
        private void When(TenderCreatedEvent tenderCreatedEvent)
        {
            if(tenderCreatedEvent.Deadline == null)
            {
                Status = TenderStatus.ACTIVE;
                Blood = tenderCreatedEvent.Blood;
            }
            else
            {
                if(DateTime.Compare(DateTime.Now, (DateTime)tenderCreatedEvent.Deadline) < 0)
                {
                    Status = TenderStatus.ACTIVE;
                    Blood = tenderCreatedEvent.Blood;
                    Deadline = tenderCreatedEvent.Deadline;
                } else
                {
                    throw new DateIsBeforeTodayException();
                }
            }

            

        }

        private void When(WinnerChosenEvent winnerChosenEvent)
        {
            Winner = winnerChosenEvent.Winner;
            Status = TenderStatus.PENDING_WINNER_CONFIRMATION;
            Modify();
        }
        
        private void When(WinnerConfirmedEvent winnerConfirmedEvent)
        {
            Status = TenderStatus.COMPLETED;
            Modify();
        }
        
        private void When(TenderFailedEvent tenderFailedEvent)
        {
            Status = TenderStatus.FAILED;
            Modify();
        }
        public void InitializeEvents() {
        } 
    }
}
