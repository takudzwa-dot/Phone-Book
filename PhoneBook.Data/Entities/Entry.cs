using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Data.Entities
{
    public class Entry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("PhoneBookID")]
        public Guid PhoneBookID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        public virtual PhoneBook  PhoneBook{get;set;}
    }
}
