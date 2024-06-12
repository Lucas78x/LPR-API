using MediatR;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Enums;
using SampleWebApiAspNetCore.Models;

namespace DigitalWorldOnline.Application.Separar.Queries
{
    public class AccountInfoChangeByIdQuery : IRequest<AccountChangeModel?>
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public ChangeTypeEnum Type { get; set; }
        public AccountInfoChangeByIdQuery(long id,string value, ChangeTypeEnum type)
        {
            Id = id;
            Value = value;
            Type = type;    
        }
    }
}

