using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System;
using System.Security.Cryptography;

namespace UrganKardesler.Areas.Admin.Services
{
    public class FileService
    {
        public static string SaveBase64Image(string base64Code)
        {
            byte[] bytes = Convert.FromBase64String(base64Code);
            var random = RandomNumberGenerator.GetInt32(15000);
            var path = Path.Combine("/images/blog", random.ToString() + ".jpeg");
            File.WriteAllBytes(path, bytes);

            //using (var imageFile = new FileStream(path ,FileMode.Create))
            //{
            //    imageFile.Write(bytes, 0, bytes.Length);
            //    imageFile.Flush();
            //}

            return random.ToString();
        }
    }
}