using MediatR;

namespace DigitalWorldOnline.Application.Admin.Queries
{
    public class GetPlaceAlertsByIdQuery : IRequest<GetPlaceAlertsByIdQueryDto>
    {
        public long Id { get; }

        public GetPlaceAlertsByIdQuery(long id)
        {
            Id = id;
        }
    }
}