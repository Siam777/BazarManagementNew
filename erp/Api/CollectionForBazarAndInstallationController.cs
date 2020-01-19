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

namespace erp.Api
{
    //public class UserInfoController : ApiController
    public class CollectionForBazarAndInstallationController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ICollectionForBazarAndInstallationService _collectionForBazarAndInstallationService;
        private readonly IStoredProcedures _storeProcedure;     
        public CollectionForBazarAndInstallationController(          
            IUnitOfWorkAsync unitOfWorkAsync
            , ICollectionForBazarAndInstallationService collectionForBazarAndInstallationService
            , IStoredProcedures storeProcedure
            )
        {            
            _unitOfWorkAsync = unitOfWorkAsync;
            _collectionForBazarAndInstallationService = collectionForBazarAndInstallationService;
            _storeProcedure = storeProcedure;
        }
        [HttpGet]
        [Route("api/CollectionForBazarAndInstallation/GetNew")]
        public CollectionForBazarAndInstallation GetNew()
        {
           var NewBazarExpenses= _collectionForBazarAndInstallationService.NewCollection();
            return NewBazarExpenses;
        }       

        [HttpPost]
        [Route("api/CollectionForBazarAndInstallation/Save")]
        public void save(CollectionForBazarAndInstallation collection)
        {
            collection.InstituteId = Sessions.InstituteId;
            _collectionForBazarAndInstallationService.Insert(_unitOfWorkAsync, collection);
          
        }
        [HttpPut]
        [Route("api/CollectionForBazarAndInstallation/update")]
        public void Update(CollectionForBazarAndInstallation collection)
        {
            //userInfo.InstituteId = Sessions.InstituteId;
            _collectionForBazarAndInstallationService.Update(_unitOfWorkAsync, collection);
        }

        [HttpGet]
        [Route("api/CollectionForBazarAndInstallation/GetCollectionList")]

        public IList<VmCollectionForBazarAndInstallation> GetCollectionInfo(int Year,int MonthId,int BazarTypeId,int UserId)
        {
            var BazarCollectionList = _collectionForBazarAndInstallationService.GetCollection(Sessions.InstituteId,Year,MonthId,BazarTypeId,UserId);
            return BazarCollectionList;
        }
        [HttpGet]
        [Route("api/GetUserInfo")]

        public IList<VmUserInfo> GetUserInfo(string text)
        {
            var UserInfoList = _storeProcedure.GetUserInfo(Sessions.InstituteId, text);
            return UserInfoList;
        }
        [HttpDelete]
        [Route("api/CollectionForBazarAndInstallation/Delete")]

        public void Delete(int Id)
        {
            _collectionForBazarAndInstallationService.Delete(Id,_unitOfWorkAsync);
            
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