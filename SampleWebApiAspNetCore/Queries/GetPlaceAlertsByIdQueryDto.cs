
using SampleWebApiAspNetCore.Dtos;

namespace DigitalWorldOnline.Application.Admin.Queries
{
    public class GetPlaceAlertsByIdQueryDto
    {
        public List<PlaceAlertsDTO>? Places { get; set; }
    }
}