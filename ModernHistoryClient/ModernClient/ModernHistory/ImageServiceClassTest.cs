using System;
using ModernHistory.Services.Impl;
using System.IO;
using System.Drawing;

namespace ModernHistory.UnitTest.Services
{
    public class ImageServiceClassTest
    {
        static ImageServiceClass imageServiceClass = new ImageServiceClass();

        public static async void TestUploadPersonImgAsync()
        {
            var personId = 1;
            var pictureName = @"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg";
             await imageServiceClass.UploadPersonImgAsync(personId, pictureName);
        }
        public static async void TestUploadEventImg()
        {
            var eventId = 1;
            var pictureName = "";
            imageServiceClass.UploadEventImgAsync(eventId, pictureName).Wait();
        }

        public static async void TestDownLoadImg()
        {
            var personId = 1;
        }

    }
}
