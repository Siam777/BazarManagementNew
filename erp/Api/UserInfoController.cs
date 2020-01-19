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
    public class UserInfoController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IUserInfoService _userInfoService;
        private readonly IMonthlyActivatedUserService _monthlyActivatedUserService;
        public UserInfoController(          
            IUnitOfWorkAsync unitOfWorkAsync
            , IUserInfoService userInfoService
            , IMonthlyActivatedUserService monthlyActivatedUserService)
        {            
            _unitOfWorkAsync = unitOfWorkAsync;
            _userInfoService = userInfoService;
            _monthlyActivatedUserService = monthlyActivatedUserService;
        }
        [HttpGet]
        [Route("api/UserInfo/UserInfoSearch")]
        public IEnumerable<VmUserInfo> GetAll()
        {
           var userInfoes= _userInfoService.GetAll(Sessions.InstituteId,false);
            return userInfoes;
        }
        [HttpGet]
        [Route("api/UserInfo/GetActivatedUsers")]
        public IEnumerable<VmUserInfo> GetActivatedUsers()
        {
            var userInfoes = _userInfoService.GetAll(Sessions.InstituteId,true);
            return userInfoes;
        }
        [HttpPost]
        [Route("api/UserInfo/SaveUserInfo")]
        public UserInfo save(UserInfo userInfo)
        {
            userInfo.InstituteId = Sessions.InstituteId;
            var result = _userInfoService.Insert(_unitOfWorkAsync, userInfo);
            return result;
        }
        [HttpPut]
        [Route("api/UserInfo/UpdateUserInfo")]
        public void Update(UserInfo userInfo)
        {
            //userInfo.InstituteId = Sessions.InstituteId;
            _userInfoService.Update(_unitOfWorkAsync, userInfo);
        }

        [HttpGet]
        [Route("api/UserInfo/UserInfoById")]

        public VmUserInfo GetUserInfo(int UserId=0)
        {
            var userInfoes = _userInfoService.GetUserInfoByUserId(UserId);
            return userInfoes;
        }
        [HttpPost]
        [Route("api/UserInfo/SaveMonthlyActivatedUser")]
        public HttpResponseMessage save(IList<MonthlyActivatedUser> MonthlyActivatedUser)
        {            
             _monthlyActivatedUserService.Save(_unitOfWorkAsync, MonthlyActivatedUser,Sessions.InstituteId);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpGet]
        [Route("api/UserInfo/GetMonthlyActivatedUser")]

        public IEnumerable<VmMonthlyActivatedUser> GetAllUsers(int MonthId,int Year)
        {
            var userInfoes = _monthlyActivatedUserService.GetAll(Sessions.InstituteId,MonthId,Year);
            return userInfoes;
        }
    }
}