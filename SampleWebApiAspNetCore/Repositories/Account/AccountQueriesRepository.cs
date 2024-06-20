
using AutoMapper;
using DigitalWorldOnline.Application.Admin.Queries;
using DigitalWorldOnline.Commons.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Enums;
using SampleWebApiAspNetCore.Models;


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

        public async Task<AccountChangeModel?> ChangeAccountInfoChangeByIdAsync(long id, string value, ChangeTypeEnum type)
        {
            var result = new AccountChangeModel();

            var dto = await _context.Account
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == id);
            if (dto != null)
            {
                switch (type)
                {
                    case ChangeTypeEnum.Email:
                        dto.Email = value;
                        break;
                    case ChangeTypeEnum.Password:
                        dto.Password = value;
                        break;
                    case ChangeTypeEnum.Nickname:
                        dto.Username = value;
                        break;
                }

                result.SetResult(true);
                _context.Update(dto);
                _context.SaveChanges();
            }
            return result;
        }

        public async Task<AccountModel?> CreateAccountAsync(AccountModel account)
        {

            var dto = _mapper.Map<AccountDTO>(account);
            _context.Add(dto);
            _context.SaveChanges();

            return account;
        }

        public async Task<PlaceAlertsModel?> CreatePlaceAlertByIdAsync(long id, PlaceAlertsModel alert)
        {

            var dto = new PlaceAlertsDTO();
            dto.SetId(alert.Id);
            dto.SetCreateDate(alert.CreateDate);
            dto.SetPlaca(alert.Placa);
            dto.SetName(alert.Name);
            dto.SetAccountdId(id);
            _context.Add(dto);
            _context.SaveChanges();

            return alert;
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
                .Where(x=> x.AccountDTOId == id)
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