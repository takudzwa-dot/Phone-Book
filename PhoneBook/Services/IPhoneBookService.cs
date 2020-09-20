using PhoneBook.Api.Models;
using System;
using System.Collections.Generic;

namespace PhoneBook.Api.Services
{
   public interface IPhoneBookService
    {
        bool DeletePhoneBook(string id);
        PhoneBookDto GetByPhoneBookID(string name);
        IEnumerable<PhoneBookDto> GetPhoneBooks();
        Guid SavePhoneBook(PhoneBookDto phoneBookDto);
        bool UpdatePhoneBook(PhoneBookDto phoneBookDto);
    }
}