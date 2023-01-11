using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Settings;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace IntegrationLibrary.Tendering.DomainEventStore
{
    public class TenderingEventStore : IEventStore<TenderingEvent>
    {
        private readonly IntegrationDbContext _context;
        
        public TenderingEventStore(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Save(TenderingEvent @event)
        {
            _context.TenderingEvents.Add(@event);
            _context.SaveChanges();
        }
    }
}