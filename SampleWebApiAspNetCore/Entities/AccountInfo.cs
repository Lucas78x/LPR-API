using SampleWebApiAspNetCore.Helpers;

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
        public void Encrypt()
        {
            Email = SHA256EncriptExtension.Encrypt(Email);
            Password = SHA256EncriptExtension.Encrypt(Password);
        }
    }
}
