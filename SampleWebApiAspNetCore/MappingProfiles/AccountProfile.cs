using AutoMapper;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Models;

namespace SampleWebApiAspNetCore.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, AccountDTO>()
               .ReverseMap();

            CreateMap<PlaceAlertsModel, PlaceAlertsDTO>()
               .ReverseMap();
        }
    }
}
