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