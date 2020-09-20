using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Models;
using PhoneBook.Api.Services;

namespace PhoneBook.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {

        private readonly IEntryService _service;

        public EntryController(IEntryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EntryDto>> GetByEntriesPhoneBookID(string phonebookID)
        {
            var result = _service.GetEntries(phonebookID);
            return new ActionResult<IEnumerable<EntryDto>>(result);
        }


        [HttpPost]
        public ActionResult<string> SaveEntry(EntryDto entryDto)
        {
            var result = _service.SaveEntry(entryDto);
            return new ActionResult<string>(result.ToString());
        }

        [HttpPut]
        public ActionResult<bool> UpdateEntry(EntryDto entryDto)
        {
            var result = _service.UpdateEntry(entryDto);
            return new ActionResult<bool>(result);
        }


        [HttpDelete]
        public ActionResult<bool> DeleteEntry(string id)
        {
            var result = _service.DeleteEntry(id);
            return new ActionResult<bool>(result);
        }
    }
}
