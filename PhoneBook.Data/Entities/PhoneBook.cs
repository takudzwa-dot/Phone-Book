using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Data.Entities
{
    public class PhoneBook
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [ForeignKey("PhoneBookID")]
        public ICollection<Entry> Entries { get; set; }
    }
}
