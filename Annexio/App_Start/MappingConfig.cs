using Annexio.Models;
using Annexio.Models.Dtos;
using AutoMapper;

namespace Annexio.App_Start
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}