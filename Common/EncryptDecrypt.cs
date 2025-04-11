
namespace Common
{
    public class EncryptDecrypt
    {
        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (Exception ex)
            {
                string excep = ex.Message;
                decrypted = "";
            }
            return decrypted;
        }
        public static string RandomString()
        {
            string possibleChars = "123456789abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            int num = 15;
            var result = new char[num];
            while (num-- > 0)
            {
                result[num] = possibleChars[random.Next(possibleChars.Length)];
            }
            return new string(result);
        }
    }
}
