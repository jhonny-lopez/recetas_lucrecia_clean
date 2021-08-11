using RecetasLucrecia.Domain.Contacts;
using RecetasLucrecia.Domain.Events;
using RecetasLucrecia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Domain.Regions
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
