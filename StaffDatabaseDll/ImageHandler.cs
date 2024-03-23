using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace StaffDatabaseDll
{
    public abstract class ImageHandler
    {
        public static byte[] ResizeBlobImage(string imagePath, int maxSize)
        {
            byte[] baseBlobImage = File.ReadAllBytes(imagePath);

            if(baseBlobImage.Length <= maxSize)
            {
                return baseBlobImage;
            }

            Image image = Image.FromStream(new MemoryStream(baseBlobImage));

            // Compute the new dimensions of the image
            float newRatio = (float)maxSize / baseBlobImage.Length;
            int newWidth = (int)(image.Width * Math.Sqrt(newRatio));
            int newHeight = (int)(image.Height * Math.Sqrt(newRatio));

            // Create a new image with the new dimensions
            Bitmap newImage = new Bitmap(image, newWidth, newHeight);

            // Convert the image into an array of bytes to store it as a BLOB
            MemoryStream ms = new MemoryStream();
            newImage.Save(ms, ImageFormat.Jpeg);
            byte[] result = ms.ToArray();
            int size = result.Length;
            return result;
        }   
    }
}
