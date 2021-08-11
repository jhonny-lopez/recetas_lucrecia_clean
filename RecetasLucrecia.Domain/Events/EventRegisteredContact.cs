using RecetasLucrecia.Domain.Contacts;
using RecetasLucrecia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Domain.Events
{
    public class EventRegisteredContact : IEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegisterDate { get; set; }

        public Contact Contact { get; set; }
        public Event Event { get; set; }
    }
}
