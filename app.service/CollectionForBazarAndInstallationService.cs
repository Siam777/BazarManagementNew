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
    public interface ICollectionForBazarAndInstallationService : IService<CollectionForBazarAndInstallation>
    {
        CollectionForBazarAndInstallation NewBazarExpense();
        IList<CollectionForBazarAndInstallation> GetBazar(int InstituteId,int Year, int MonthId,int BazarTypeId);
        void Insert(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation BazarExpense);       
        void Update(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation BazarExpense);
        void Delete(int Id, IUnitOfWorkAsync unitOfWorkAsync);
    }

    public class BazarExpenseService:Service<CollectionForBazarAndInstallation>, IBazarExpenseService
    {
        private readonly IRepositoryAsync<CollectionForBazarAndInstallation> _repository;
        private readonly IBazarTypeService _bazarTypeService;
        public BazarExpenseService(IRepositoryAsync<CollectionForBazarAndInstallation> repository,
           IBazarTypeService bazarTypeService
           )
            : base(repository)
        {
            _repository = repository;
            _bazarTypeService = bazarTypeService;
        }

        public CollectionForBazarAndInstallation NewBazarExpense()
        {
            var Collection = new CollectionForBazarAndInstallation();
            BazarExpense.BazarTypeList = _bazarTypeService.GetKVP();
            return BazarExpense;
        }
        
        public IList<CollectionForBazarAndInstallation> GetBazar(int InstituteId,int Year,int MonthId,int BazarTypeId)
        {
            var BazarExpenseList = _repository.Query(x => x.InstituteId == InstituteId && x.MonthId == MonthId && x.BazarTypeId==BazarTypeId)                
                .Select().ToList();
            return BazarExpenseList;
        }
        public CollectionForBazarAndInstallation GetBazarById(int Id)
        {
            var Collection = _repository.Query(x => x.Id == Id)
                .Select().SingleOrDefault();
            return BazarExpense;
        }
        public void Insert(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation Collection)
        {
            _repository.Insert(Collection);
            unitOfWorkAsync.SaveChanges();            
        }
        public void Update(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation BazarExpense)
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
