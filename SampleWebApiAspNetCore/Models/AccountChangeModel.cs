using SampleWebApiAspNetCore.Enums;

namespace SampleWebApiAspNetCore.Models
{
    public class AccountChangeModel
    {
        public bool Result { get; set; }

        public void SetResult(bool result) => Result = result;

    }
}
