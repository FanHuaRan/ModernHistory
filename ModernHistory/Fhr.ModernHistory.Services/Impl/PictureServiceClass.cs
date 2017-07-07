using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Fhr.ModernHistory.Utils;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// 图片服务实现
      /// 2017/07/07 fhr
      /// </summary>
      public class PictureServiceClass : IPictureService
      {
            //图片根目录
            private static readonly string PICTURE_ROOT = ConfigHelper.ReadAppConfig("pictureroot");
            //人员文件夹
            private static readonly string PERSON_DIR = "person";
            //事件文件夹
            private static readonly string EVENT_DIR = "event";

            public Stream GetEventImageFile(object eventId)
            {
                  var fileName = string.Format("{0}\\{1}\\{2}.jpg",PICTURE_ROOT, EVENT_DIR, eventId);
                  if (!File.Exists(fileName))
                  {
                        return null;
                  }
                  return new FileStream(fileName, FileMode.Open);
            }

            public Stream GetPersonImageFile(object personId)
            {
                  var fileName = string.Format("{0}\\{1}\\{2}.jpg", PICTURE_ROOT, PERSON_DIR, personId);
                  if (!File.Exists(fileName))
                  {
                        return null;
                  }
                  return new FileStream(fileName, FileMode.Open);
            }

            public void SaveEventImageFile(HttpPostedFile eventImg, object eventId)
            {
                  var fileName = string.Format("{0}\\{1}\\{2}.jpg", PICTURE_ROOT, EVENT_DIR, eventId);
                  if (File.Exists(fileName))
                  {
                        File.Delete(fileName);
                  }
                  eventImg.SaveAs(fileName);
            }

            public void SavePersonImagFile(HttpPostedFile personImg, object personId)
            {
                  var fileName = string.Format("{0}\\{1}\\{2}.jpg", PICTURE_ROOT, PERSON_DIR, personId);
                  if (File.Exists(fileName))
                  {
                        File.Delete(fileName);
                  }
                  personImg.SaveAs(fileName);
            }
      }
}
