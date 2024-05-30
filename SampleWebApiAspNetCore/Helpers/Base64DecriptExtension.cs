using System.Text;

namespace SampleWebApiAspNetCore.Helpers
{
    public static class Base64DecriptExtension
    {
        public static string Base64Decrypt(this string toDecrypt)
        {
            try { return Encoding.ASCII.GetString(Convert.FromBase64String(toDecrypt)); }
            catch { return toDecrypt; }
        }
    }
}
