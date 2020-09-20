using AutoMapper;
using Microsoft.Extensions.Logging;
using PhoneBook.Api.Models;
using PhoneBook.Data.Context;
using PhoneBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Api.Services
{
    class EntryService : IEntryService
    {
        private readonly PhoneBookContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EntryService(PhoneBookContext context, IMapper mapper, ILogger<PhoneBookService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<EntryDto> GetEntries(string phonebookId)
        {
            var entry = _context.Entry.ToList();
            var result = entry
                .Select(x => _mapper.Map<EntryDto>(x))
                .Where(x => x.PhoneBookID.ToString() == phonebookId);
            return result;
        }

        public Guid SaveEntry(EntryDto entryDto)
        {
            try
            {
                var entryEntity = _mapper.Map<Entry>(entryDto);

                _logger.LogDebug("Saving entry");

                _context.Entry.Add(entryEntity);
                _context.SaveChanges();

                return entryEntity.ID;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
            }

            return Guid.Empty;
        }

        public bool UpdateEntry(EntryDto entryDto)
        {
            if (entryDto == null)
                return false;

            var entry = _context.Entry.Where(x => x.ID.ToString() == entryDto.ID).FirstOrDefault();
            if (entry == null)
                return false;

            entry.PhoneBookID = Guid.Parse(entryDto.PhoneBookID);
            entry.Name = entryDto.Name;
            entry.PhoneNumber = int.Parse(entryDto.PhoneNumber);

            _context.Update(entry);
            var result = _context.SaveChanges();

            return result == 1;
        }

        public bool DeleteEntry(string entryID)
        {
            var entry = _context.Entry.Where(x => x.ID.ToString() == entryID).FirstOrDefault();
            if (entry == null)
                return false;

            _context.Entry.Remove(entry);
            var result = _context.SaveChanges();
            return result == 1;
        }
    }
}
