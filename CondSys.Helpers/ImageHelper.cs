using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CondSys.Helpers
{
    public static class ImageHelper
    {
        public static byte[] Base64ToByteArray(string base64String)
        {
            if (String.IsNullOrEmpty(base64String))
            {
                return new byte[0];
            }

            try
            {
                base64String = base64String.Replace("data:image/png;base64,", "");

                var bytes = Convert.FromBase64String(base64String);
                return bytes;
            }
            catch
            {
                throw new Exception();
            }
        }

        public static string ArrayByteToBase64(byte[] byteArray)
        {
            if (byteArray.Length == 0)
            {
                return string.Empty;
            }
            try
            {
                var base64 = "data:image/png;base64," + Convert.ToBase64String(byteArray);
                return base64;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro na conversão para imagem", ex);
            }
        }

        public static string FileToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
