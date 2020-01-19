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
    public class MealManagementController : ApiController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IMealManagementService _mealManagementService;
        private readonly IStoredProcedures _storeProcedures;   
        public MealManagementController(          
            IUnitOfWorkAsync unitOfWorkAsync
            , IMealManagementService mealManagementService
            , IStoredProcedures storeProcedures
            )
        {            
            _unitOfWorkAsync = unitOfWorkAsync;
            _mealManagementService = mealManagementService;
            _storeProcedures = storeProcedures;
        }
        [HttpPost]
        [Route("api/MealManagement/save")]
        public void save(List<MealManagement>MealManagement) {
            _mealManagementService.Save(_unitOfWorkAsync, MealManagement, Sessions.InstituteId);
        }
        [HttpGet]
        [Route("api/MealManagement/GetAllByDate")]
        public List<VmMealManagement> MealManagement(string Date)
        {
            var List = _storeProcedures.GetMealManagementList(Sessions.InstituteId,Date);
            return List;
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