namespace SampleWebApiAspNetCore.Entities
{
    public class AccountInfo
    { 
        /// <summary>
      /// Email
      /// </summary>
        public string Email{ get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        public AccountInfo(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
