using System;

namespace PhoneBook.Api.Models
{
    public class EntryDto
    {
        public string ID { get; set; }
        public string PhoneBookID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
