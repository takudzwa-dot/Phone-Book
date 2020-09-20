using AutoMapper;
using Microsoft.Extensions.Logging;
using PhoneBook.Api.Models;
using PhoneBook.Data.Context;
using PhoneBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PhoneBook.Api.Services
{
    class PhoneBookService : IPhoneBookService
    {
        private readonly PhoneBookContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PhoneBookService(PhoneBookContext context, IMapper mapper, ILogger<PhoneBookService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<PhoneBookDto> GetPhoneBooks()
        {
            var phonebook = _context.PhoneBook
                .Include(x => x.Entries)
                .ToList();

            var result = phonebook.Select(x => _mapper.Map<PhoneBookDto>(x));
            return result;
        }

        public Guid SavePhoneBook(PhoneBookDto phoneBookDto)
        {
            try
            {
                var phonebookEntity = _mapper.Map<Data.Entities.PhoneBook>(phoneBookDto);

                _logger.LogDebug("Saving phonebook");

                _context.PhoneBook.Add(phonebookEntity);
                _context.SaveChanges();

                return phonebookEntity.ID;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
            }

            return Guid.Empty;
        }

        public bool UpdatePhoneBook(PhoneBookDto phoneBookDto)
        {
            if (phoneBookDto == null)
                return false;

            var phonebook = _context.PhoneBook.Where(x => x.ID.ToString() == phoneBookDto.ID).FirstOrDefault();
            if (phonebook == null)
                return false;

            phonebook.Name = phoneBookDto.Name;

            _context.Update(phonebook);
            var result = _context.SaveChanges();

            return result == 1;
        }

        public PhoneBookDto GetByPhoneBookID(string id)
        {
            var phonebookEntity = GetByPhoneBookRecordID(Guid.Parse(id));
                 
            var result = _mapper.Map<PhoneBookDto>(phonebookEntity);
            return result;
        }

        public bool DeletePhoneBook(string id)
        {
            var phonebook = _context.PhoneBook.Where(x => x.ID.ToString() == id).FirstOrDefault();
            if (phonebook == null)
                return false;

            _context.PhoneBook.Remove(phonebook);
            var result = _context.SaveChanges();
            return result == 1;
        }

        private Data.Entities.PhoneBook GetByPhoneBookRecordID(Guid id)
        {
            IQueryable<Data.Entities.PhoneBook> query = _context.PhoneBook
                .Where(e => e.ID == id)
                .Include(x => x.Entries);

            var phonebookEntity = query.FirstOrDefault();
            return phonebookEntity;
        }


    }
}
