using erp;
using app.Entities.Models;
using app.Service;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using static erp.MvcApplication;
using app.Entities.ViewModels;
using System.Web;
using System.IO;

namespace erp.Api
{
    //public class UserInfoController : ApiController
    public class BazarExpenseController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IBazarExpenseService _bazarExpenseService;       
        public BazarExpenseController(          
            IUnitOfWorkAsync unitOfWorkAsync
            , IBazarExpenseService bazarExpenseService
            )
        {            
            _unitOfWorkAsync = unitOfWorkAsync;
            _bazarExpenseService = bazarExpenseService;            
        }
        [HttpGet]
        [Route("api/BazarExpense/GetNew")]
        public BazarExpense GetNew()
        {
           var NewBazarExpenses= _bazarExpenseService.NewBazarExpense();
            return NewBazarExpenses;
        }       

        [HttpPost]
        [Route("api/BazarExpernse/Save")]
        public void save(BazarExpense expense)
        {
           
                //string fileName;
                //var docfiles = new List<string>();
                //foreach (string file in httpRequest.Files)
                //{
                //    string path = HttpContext.Current.Server.MapPath("~/Upload/");
                //    if (!Directory.Exists(path))
                //    {
                //        Directory.CreateDirectory(path);
                //    }
                //    var postedFile = httpRequest.Files[file];
                //    var actualFileName = postedFile.FileName;
                //     fileName = Guid.NewGuid() + Path.GetExtension(postedFile.FileName);
                //    string NFileName = Path.GetFileName(actualFileName);
                //    string fileExtension = Path.GetExtension(NFileName);
                //    int size = postedFile.ContentLength;
                //    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                //   fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                //    {
                //        postedFile.SaveAs(Path.Combine(HttpContext.Current.Server.MapPath("~/Upload"), fileName));
                //        Stream stream = postedFile.InputStream;
                //        BinaryReader binaryReader = new BinaryReader(stream);
                //        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                //        expense.ImageBinary = bytes;
                //        expense.ImagePath = "Upload/" + fileName;
                //        //  postedFile.SaveAs(Path.Combine(Server.MapPath("~/Upload"), fileName))
                //        //image.ImageBinaryData = bytes;
                //    }
                   // file.SaveAs(Path.Combine(Server.MapPath("~/Upload"), fileName));
                    // int hasheddate = DateTime.Now.GetHashCode();

                    //Good to use an updated name always, since many can use the same file name to upload.
                    //  string changed_name = hasheddate.ToString() + "_" + postedFile.FileName;

                    //  var filePath = HttpContext.Current.Server.MapPath("~/Images/" + changed_name);
                    //   postedFile.SaveAs(filePath); // save the file to a folder "Images" in the root of your app

                    // changed_name = @"~\Images\" + changed_name; //store this complete path to database
                    //  docfiles.Add(changed_name);

               // }
            //}
                expense.InstituteId = Sessions.InstituteId;
            _bazarExpenseService.Insert(_unitOfWorkAsync, expense);
          
        }
        [HttpPut]
        [Route("api/BazarExpernse/update")]
        public void Update(BazarExpense expense)
        {
            //userInfo.InstituteId = Sessions.InstituteId;
            _bazarExpenseService.Update(_unitOfWorkAsync, expense);
        }

        [HttpGet]
        [Route("api/BazarExpense/GetBazarExpenseList")]

        public IList<BazarExpense> GetBazarInfo(int Year,int MonthId,int BazarTypeId)
        {
            var BazarExpenseList = _bazarExpenseService.GetBazar(Sessions.InstituteId,Year,MonthId,BazarTypeId);
            return BazarExpenseList;
        }
        [HttpGet]
        [Route("api/BazarExpense/GetBazarExpenseById")]

        public BazarExpense GetBazarInfoById(int id)
        {
            var BazarExpense = _bazarExpenseService.GetBazarById(id);
            return BazarExpense;
        }
        [HttpDelete]
        [Route("api/BazarExpense/Delete")]

        public void Delete(int Id)
        {
             _bazarExpenseService.Delete(Id,_unitOfWorkAsync);
            
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}