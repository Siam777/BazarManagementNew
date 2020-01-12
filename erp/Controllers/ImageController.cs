using app.Entities.Models;
using app.Service;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using static erp.MvcApplication;

namespace erp.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public ImageController(IImageService imageService,
            IUnitOfWorkAsync unitOfWorkAsync)
        {
            _imageService = imageService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
      public ActionResult Index()
        {
            return View();
        }    
        [HttpPost]
       public ContentResult Upload()
        {
            string path = Server.MapPath("~/Upload/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach(string key in Request.Files)
            {
                HttpPostedFileBase postedfile = Request.Files[key];
                postedfile.SaveAs(path + postedfile.FileName);
            }
            return Content("Success");
        }
        [HttpPost]
        public JsonResult SaveFiles(int UserId)
        {
            string Message, fileName, actualFileName;
            Image image = new Image();
             Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if(Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string NFileName = Path.GetFileName(actualFileName);
                string fileExtension = Path.GetExtension(NFileName);
                int size = file.ContentLength;
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                   fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                {
                    Stream stream = file.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes=binaryReader.ReadBytes((int)stream.Length);
                    image.ImageBinaryData = bytes;
                }                
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Upload"), fileName));

                    image.ImagePath = "Upload/"+fileName;
                    image.UserId = UserId;
                    _imageService.SaveImage(image, _unitOfWorkAsync);                    
                    //AppContext dc = new AppContext();
                    
                    //    dc.Image.Add(image);
                    //    dc.SaveChanges();
                    //    Message = "File Uploaded SuccessFully";
                    //    flag = true;
                    
                }
                catch (Exception)
                {

                    Message = "Photo Upload Failed";
                }
            }
            return new JsonResult { Data = new { Message = Message, status = flag } };
        }
        //[Route("Image/GetById")]
        //[HttpGet]
        //public HttpResponseMessage GetImageById()
        //{            
        //        var image = _imageService.GetImageById(1);
        //        var result = new HttpResponseMessage(HttpStatusCode.OK);
        //        if (image != null && image.ImageBinaryData != null)
        //        {
        //            Stream stream = new MemoryStream(image.ImageBinaryData);
        //            result.Content = new ByteArrayContent(image.ImageBinaryData);
        //            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //            string imageBase64 = Convert.ToBase64String(image.ImageBinaryData);
        //            string imageSrc = string.Format("data:image/jpg;base64,{0}", imageBase64);
        //    }
        //        else
        //        {
        //            result = new HttpResponseMessage(HttpStatusCode.NotFound);

        //        }

        //        return result;                      
        //   // return image;
        //}
        [Route("Image/GetById")]
        [HttpGet]
        public string GetImageById()
        {            
            var image = _imageService.GetImageById(2);
            return image.ImagePath;            
           // return image;
        }
   
}
}