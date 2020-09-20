using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Api.Models;
using PhoneBook.Api.Services;


namespace PhoneBook.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _service;

        public PhoneBookController(IPhoneBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhoneBookDto>> GetPhoneBooks()
        {
            var result = _service.GetPhoneBooks();
            return new ActionResult<IEnumerable<PhoneBookDto>>(result);
        }


        [HttpGet("{id}")]
        public ActionResult<PhoneBookDto> GetPhoneBook(string id)
        {
            var result = _service.GetByPhoneBookID(id);
            return new ActionResult<PhoneBookDto>(result);
        }


        [HttpPost]
        public ActionResult<string> SavePhoneBook(PhoneBookDto phoneBookDto)
        {
           var result = _service.SavePhoneBook(phoneBookDto);
            return new ActionResult<string>(result.ToString());
        }

        [HttpPut]
        public ActionResult<bool> UpdatePhoneBook(PhoneBookDto phoneBookDto)
        {
            var result = _service.UpdatePhoneBook(phoneBookDto);
            return new ActionResult<bool>(result);
        }


        [HttpDelete("{id}")]
        public ActionResult<bool> DeletePhoneBook(string id)
        {
            var result = _service.DeletePhoneBook(id);
            return new ActionResult<bool>(result);
        }
    }
}
