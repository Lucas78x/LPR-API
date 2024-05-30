using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Helpers;

namespace SampleWebApiAspNetCore.Converters
{

    public static class AccountInfoRequestCommandConverter
    {
        public static AccountInfo Convert(AccountInfo account)
        {
            return new AccountInfo(
                account.Email.Base64Decrypt(),          
                account.Password.Base64Decrypt());
        }
    }   
}
