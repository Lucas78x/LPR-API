using DigitalWorldOnline.Commons.Interfaces;
using MediatR;


namespace DigitalWorldOnline.Application.Admin.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetPlaceAlertsByIdQuery, GetPlaceAlertsByIdQueryDto>
    {
        private readonly IAccountQueriesRepository _repository;

        public GetUserByIdQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPlaceAlertsByIdQueryDto> Handle(GetPlaceAlertsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPlaceAlertsByIdAsync(request.Id);
        }
    }
}