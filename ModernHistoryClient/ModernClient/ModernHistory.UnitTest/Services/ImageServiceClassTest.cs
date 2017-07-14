using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernHistory.Services.Impl;

namespace ModernHistory.UnitTest.Services
{
    [TestClass]
    public class ImageServiceClassTest
    {
        ImageServiceClass imageServiceClass = new ImageServiceClass();

        [TestMethod]
        public void TestUploadPersonImgAsync()
        {
            var personId = 1;
            var pictureName = @"C:\Users\Public\Pictures\Sample Pictures\沙漠.jpg";
            imageServiceClass.UploadPersonImgAsync(personId, pictureName).Wait();
        }
        public async void TestUploadEventImg()
        {
            var eventId = 1;
            var pictureName = "";
            imageServiceClass.UploadEventImgAsync(eventId, pictureName).Wait();
        }
    }
}
