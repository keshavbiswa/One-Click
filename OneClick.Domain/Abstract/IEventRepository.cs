using OneClick.Domain._Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Abstract
{
    public interface IEventRepository
    {
        IEnumerable<Event> Events { get; }

        void SaveEvent(Event events);

        Event DeleteEvent(int eventId);
    }
}
