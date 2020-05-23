using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using app.Entities.Models;
using Repository.Pattern.Repositories;
using Repository.Pattern.Ef6;
using Service.Pattern;
using LinqKit;
using Repository.Pattern.UnitOfWork;
using app.Entities.ViewModels;

namespace app.Service
{
    public interface IBazarExpenseService : IService<BazarExpense>
    {
        BazarExpense NewBazarExpense();
        IList<BazarExpense> GetBazar(int InstituteId,int Year, int MonthId,int BazarTypeId);
        void Insert(IUnitOfWorkAsync unitOfWorkAsync, BazarExpense BazarExpense);       
        void Update(IUnitOfWorkAsync unitOfWorkAsync, BazarExpense BazarExpense);
        void Delete(int Id, IUnitOfWorkAsync unitOfWorkAsync);
         BazarExpense GetBazarById(int Id);
    }

    public class BazarExpenseService:Service<BazarExpense>, IBazarExpenseService
    {
        private readonly IRepositoryAsync<BazarExpense> _repository;
        private readonly IBazarTypeService _bazarTypeService;
        public BazarExpenseService(IRepositoryAsync<BazarExpense> repository,
           IBazarTypeService bazarTypeService
           )
            : base(repository)
        {
            _repository = repository;
            _bazarTypeService = bazarTypeService;
        }

        public BazarExpense NewBazarExpense()
        {
            var BazarExpense = new BazarExpense();
            BazarExpense.BazarTypeList = _bazarTypeService.GetKVP();
            return BazarExpense;
        }
        
        public IList<BazarExpense> GetBazar(int InstituteId,int Year,int MonthId,int BazarTypeId)
        {
            var BazarExpenseList = _repository.Query(x => x.InstituteId == InstituteId && x.MonthId == MonthId && x.BazarTypeId==BazarTypeId)                
                .Select().ToList();
            return BazarExpenseList;
        }
        public BazarExpense GetBazarById(int Id)
        {
            var BazarExpense = _repository.Query(x => x.Id == Id)
                .Select().SingleOrDefault();
            return BazarExpense;
        }
        public void Insert(IUnitOfWorkAsync unitOfWorkAsync, BazarExpense BazarExpense)
        {
            _repository.Insert(BazarExpense);
            unitOfWorkAsync.SaveChanges();            
        }
        public void Update(IUnitOfWorkAsync unitOfWorkAsync, BazarExpense BazarExpense)
        {           
            _repository.Update(BazarExpense);
            unitOfWorkAsync.SaveChanges();
        }
        public void Delete(int Id,IUnitOfWorkAsync unitOfWorkAsync)
        {
            BazarExpense Expense = new BazarExpense();
            Expense = GetBazarById(Id);
            _repository.Delete(Expense);
            unitOfWorkAsync.SaveChanges();
        }
    }
}
