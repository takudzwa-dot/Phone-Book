using AutoMapper;
using PhoneBook.Data.Entities;

namespace PhoneBook.Api.Models.Mapper
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            SetupMappings();
        }
        private void SetupMappings()
        {
            // Dto -> Entity
            CreateMap<PhoneBookDto, Data.Entities.PhoneBook>();
            CreateMap<PhoneBookUpdateDto, Data.Entities.PhoneBook>();
            CreateMap<EntryDto, Entry>();
            
            //Entity -> Dto
            CreateMap<Data.Entities.PhoneBook, PhoneBookDto>();
            CreateMap<Entry, EntryDto>();
        }
    }
}
