
using DigitalWorldOnline.Application.Admin.Queries;
using SampleWebApiAspNetCore.Dtos;

namespace DigitalWorldOnline.Commons.Interfaces
{
    public interface IAccountQueriesRepository
    {
        Task<AccountDTO?> GetAccountByUsernameAsync(string email,string password);
        Task<GetPlaceAlertsByIdQueryDto> GetPlaceAlertsByIdAsync(long id);
    }
}