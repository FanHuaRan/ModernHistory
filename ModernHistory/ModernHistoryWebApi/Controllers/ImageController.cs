using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Fhr.ModernHistory.Services;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// 图片下载控制器
      /// http://www.cnblogs.com/qixiaoyizhan/p/6912321.html
      /// </summary>
      public class ImageController : ApiController
      {
            public IPictureService PictureService { get; set; }

            public ImageController(IPictureService pictureService)
            {
                  this.PictureService = pictureService;
            }
            [HttpPost]
            public void UplodPersonImg(int id)
            {
                  if (HttpContext.Current.Request.Files.Count > 0)
                  {
                        HttpPostedFile imgFile = HttpContext.Current.Request.Files[0];
                        //保存图片文件
                        PictureService.SavePersonImagFile(imgFile, id);
                  }

            }
            [HttpPost]
            public void UploadEventImg(int id)
            {
                  if (HttpContext.Current.Request.Files.Count > 0)
                  {
                        HttpPostedFile imgFile = HttpContext.Current.Request.Files[0];
                        //保存图片文件
                        PictureService.SaveEventImageFile(imgFile, id);
                  }
            }
            public HttpResponseMessage GetPersonImg(int id)
            {
                  var fs = PictureService.GetPersonImageFile(id);
                  if (fs == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "没有该图片");
                  }
                  var result = CreateImageResponseMessage(id, fs);
                  return result;
            }

            public HttpResponseMessage GetEventImg(int id)
            {
                  var fs = PictureService.GetEventImageFile(id);
                  if (fs == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "没有该事件");
                  }
                  var result = CreateImageResponseMessage(id, fs);
                  return result;
            }


            private static HttpResponseMessage CreateImageResponseMessage(int id, Stream fs)
            {
                  var result = new HttpResponseMessage(HttpStatusCode.OK);
                  result.Content = new StreamContent(fs);
                  result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                  result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                  result.Content.Headers.ContentDisposition.FileName = id.ToString();
                  return result;
            }
      }
}