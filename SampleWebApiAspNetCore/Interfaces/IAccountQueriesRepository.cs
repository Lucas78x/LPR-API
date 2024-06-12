
using DigitalWorldOnline.Application.Admin.Queries;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Enums;
using SampleWebApiAspNetCore.Models;

namespace DigitalWorldOnline.Commons.Interfaces
{
    public interface IAccountQueriesRepository
    {
        Task<AccountChangeModel?> ChangeAccountInfoChangeByIdAsync(long id, string value, ChangeTypeEnum type);
        Task<PlaceAlertsModel?> CreatePlaceAlertByIdAsync(long id, PlaceAlertsModel alert);
        Task<AccountDTO?> GetAccountByUsernameAsync(string email,string password);
        Task<GetPlaceAlertsByIdQueryDto> GetPlaceAlertsByIdAsync(long id);
    }
}