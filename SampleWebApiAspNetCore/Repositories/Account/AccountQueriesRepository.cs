
using AutoMapper;
using DigitalWorldOnline.Application.Admin.Queries;
using DigitalWorldOnline.Commons.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Dtos;


namespace DigitalWorldOnline.Infrastructure.Repositories.Account
{
    public class AccountQueriesRepository : IAccountQueriesRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public AccountQueriesRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountDTO?> GetAccountByUsernameAsync(string email, string password)
        {
            var dto = await _context.Account
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Email == email);

            if (dto != null)
            {
                if (dto.Password == password)
                {
                    return dto;
                }
                else
                {
                    dto.Password = string.Empty;
                }
            }
            return dto;
        }

        public async Task<GetPlaceAlertsByIdQueryDto> GetPlaceAlertsByIdAsync(long id)
        {

            var alerts = await _context.Alerts
                .AsNoTracking()
                .Where(x => x.OwnerId == id)
                .ToListAsync();

            if (!alerts.Any())
                return new GetPlaceAlertsByIdQueryDto();


            var placeAlertsDto = _mapper.Map<List<PlaceAlertsDTO>>(alerts);

            var result = new GetPlaceAlertsByIdQueryDto
            {
                Places = placeAlertsDto
            };

            return result;
        }
    }
}