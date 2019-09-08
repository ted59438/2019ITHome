using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace IT_Day01
{
    public class PhotoHelper
    {
        /// <summary>
        /// 圖片轉Bytes
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image img)
        {
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, ImageFormat.Jpeg);

            return memoryStream.ToArray();
        }

        /// <summary>
        /// Bytes轉圖片
        /// </summary>
        /// <param name="imgBytes"></param>
        /// <returns></returns>
        public static Image bytesToImage(byte[] imgBytes)
        {
            MemoryStream memoryStream = new MemoryStream(imgBytes);

            return Image.FromStream(memoryStream);
        }

        public static MemoryStream readImageStreamFromFile(string imagePath)
        {
            MemoryStream memoryStream = new MemoryStream();

            Image imageFile = Image.FromFile(imagePath);
            imageFile.Save(memoryStream, ImageFormat.Jpeg);
            imageFile.Dispose();

            return memoryStream;

        }
    }
}
