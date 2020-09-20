using PhoneBook.Api.Models;
using System;
using System.Collections.Generic;

namespace PhoneBook.Api.Services
{
    public interface IEntryService
    {
        bool DeleteEntry(string entryID);
        IEnumerable<EntryDto> GetEntries(string phonebookId);
        Guid SaveEntry(EntryDto entryDto);
        bool UpdateEntry(EntryDto entryDto);
    }
}