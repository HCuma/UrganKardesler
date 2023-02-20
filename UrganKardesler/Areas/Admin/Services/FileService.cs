using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System;
using System.Security.Cryptography;

namespace UrganKardesler.Areas.Admin.Services
{
    public class FileService
    {
        public static string SaveBase64Image(string base64Code, string directoryPath)
        {
            byte[] bytes = Convert.FromBase64String(base64Code);

            var fileName = (Directory.GetFiles(directoryPath).Length + 1) + ".jpg";
            var path = Path.Combine(directoryPath, fileName);
            try
            {
                File.WriteAllBytes(path, bytes);
            }
            catch (Exception)
            {
                throw;
            }

            //using (var imageFile = new FileStream(path ,FileMode.Create))
            //{
            //    imageFile.Write(bytes, 0, bytes.Length);
            //    imageFile.Flush();
            //}

            return fileName;
        }
    }
}