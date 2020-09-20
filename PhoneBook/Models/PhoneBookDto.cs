using System.Collections.Generic;

namespace PhoneBook.Api.Models
{
    public class PhoneBookDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ICollection<EntryDto> Entries { get; set; }
    }
}
