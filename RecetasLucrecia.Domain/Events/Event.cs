using RecetasLucrecia.Domain.Contacts;
using RecetasLucrecia.Domain.Regions;
using RecetasLucrecia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Domain.Events
{
    public class Event : IEntity
    {
        public Guid Id { get; set; }
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int CityId { get; set; }
        public string LocationName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool IsActive { get; set; }

        public EventType EventType { get; set; }
        public EventCategory EventCategory { get; set; }
        public City City { get; set; }

        public EventRegisteredContact RegisterContact(Contact contact)
        {
            EventRegisteredContact eventRegisteredContact = new EventRegisteredContact();
            eventRegisteredContact.ContactId = contact.Id;
            eventRegisteredContact.EventId = this.Id;
            eventRegisteredContact.RegisterDate = DateTime.Now;

            //Verifica si el evento ya excedió la cantidad de contactos permitido

            if (contact.CityId != this.CityId)
            {
                throw new Exception("El contacto no se encuentra en la misma ciudad del evento");
            }

            return eventRegisteredContact;
        }
    }
}
