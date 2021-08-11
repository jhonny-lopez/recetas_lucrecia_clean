using RecetasLucrecia.Domain.Regions;
using RecetasLucrecia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Domain.Contacts
{
    public class Contact : IEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ContactMethods ContactBy { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
