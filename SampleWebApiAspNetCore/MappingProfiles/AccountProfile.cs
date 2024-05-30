using AutoMapper;
using SampleWebApiAspNetCore.Dtos;

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
