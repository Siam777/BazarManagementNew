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
    public class BazarReportController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IStoredProcedures _storeProcedures;
        public BazarReportController(          
            IUnitOfWorkAsync unitOfWorkAsync
            , IStoredProcedures storeProcedures
            )
        {            
            _unitOfWorkAsync = unitOfWorkAsync;
            _storeProcedures = storeProcedures;            
        }
        [HttpGet]
        [Route("api/BazarReport/Process")]
        public string Process(int MonthId,int Year)
        {
           var ProcessMessage= _storeProcedures.BazarProcess(Sessions.InstituteId, MonthId,Year);
            return ProcessMessage;
        }
        [HttpGet]
        [Route("api/BazarReport/GetReport")]
        public List<VmBazarReport> GetReport(int MonthId, int Year,int BazarReportId)
        {
            var List = _storeProcedures.GetBazarReport(Sessions.InstituteId, MonthId, Year, BazarReportId);
            return List;
        }
        [HttpGet]
        [Route("api/BazarReport/GetMealInfo")]
        public List<VmMealInfo> GetMealInfo(int MonthId, int Year)
        {
            var List = _storeProcedures.MonthlyMealInfo(Sessions.InstituteId, MonthId,Year);
            return List;
        }
    }
}