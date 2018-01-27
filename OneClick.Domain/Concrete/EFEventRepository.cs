using OneClick.Domain._Entities;
using OneClick.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Concrete
{
   public class EFEventRepository : IEventRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Event> Events
        {
            get { return context.Events; }
        }

        public void SaveEvent(Event events)
            {
                 if (events.EventId == 0)
                {
                  context.Events.Add(events);
                 }
                else
                {
                    Event dbEntry = context.Events.Find(events.EventId);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = events.Name;
                       dbEntry.Description = events.Description;
                       dbEntry.Time = events.Time;
                       dbEntry.Category = events.Category;
                   }
                 }
                context.SaveChanges();
            }


         public Event DeleteEvent(int eventId)
            {
             Event dbEntry = context.Events.Find(eventId);
             if(dbEntry != null)
             {
                context.Events.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
