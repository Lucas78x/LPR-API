using System.Text;

namespace SampleWebApiAspNetCore.Helpers
{
    public static class Base64EncriptExtension
    {
        public static string Encrypt(this string toEncrypt)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(toEncrypt));
        }
    }
}
