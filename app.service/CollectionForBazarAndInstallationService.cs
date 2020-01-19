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
        CollectionForBazarAndInstallation NewCollection();
        IList<VmCollectionForBazarAndInstallation> GetCollection(int InstituteId,int Year, int MonthId,int BazarTypeId,int UserId);
        void Insert(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation Collection);       
        void Update(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation Collection);
        void Delete(int Id, IUnitOfWorkAsync unitOfWorkAsync);
    }

    public class CollectionForBazarAndInstallationService: Service<CollectionForBazarAndInstallation>, ICollectionForBazarAndInstallationService
    {
        private readonly IRepositoryAsync<CollectionForBazarAndInstallation> _repository;
        private readonly IBazarTypeService _bazarTypeService;
        private readonly IUserInfoService _userInfoService;
        public CollectionForBazarAndInstallationService(IRepositoryAsync<CollectionForBazarAndInstallation> repository,
           IBazarTypeService bazarTypeService,
           IUserInfoService userInfoService
           )
            : base(repository)
        {
            _repository = repository;
            _bazarTypeService = bazarTypeService;
            _userInfoService = userInfoService;
        }

        public CollectionForBazarAndInstallation NewCollection()
        {
            var Collection = new CollectionForBazarAndInstallation();
            Collection.BazarTypeList = _bazarTypeService.GetKVP();
            return Collection;
        }
        
        public IList<VmCollectionForBazarAndInstallation> GetCollection(int InstituteId,int Year,int MonthId,int BazarTypeId,int UserId)
        {
            var CollectionListUserWise = new List<VmCollectionForBazarAndInstallation>();
            var CollectionList = new List<CollectionForBazarAndInstallation>();
            if (UserId != 0)
            {
                 CollectionList = _repository.Query(x => x.InstituteId == InstituteId && x.MonthId == MonthId && x.BazarTypeId == BazarTypeId && x.UserId==UserId)
                    .Select().ToList();
            }
            else
            {
                CollectionList = _repository.Query(x => x.InstituteId == InstituteId && x.MonthId == MonthId && x.BazarTypeId == BazarTypeId)
                    .Select().ToList();
            }
            foreach(var item in CollectionList)
            {
                VmCollectionForBazarAndInstallation collection = new VmCollectionForBazarAndInstallation();
                var UserInfo = _userInfoService.GetUserInfoByUserId(item.UserId);
                collection.Id = item.Id;
                collection.UserId = item.UserId;
                collection.Year = item.Year;
                collection.MonthId = item.MonthId;
                collection.InstituteId = item.InstituteId;
                collection.Collection = item.Collection;
                collection.BazarTypeId = item.BazarTypeId;
                collection.CollectionDate = item.CollectionDate;
                collection.Name = UserInfo.Name;
                CollectionListUserWise.Add(collection);
            }
            return CollectionListUserWise;
        }
        public CollectionForBazarAndInstallation GetCollectionById(int Id)
        {
            var Collection = _repository.Query(x => x.Id == Id)
                .Select().SingleOrDefault();
            return Collection;
        }
        public void Insert(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation Collection)
        {
            _repository.Insert(Collection);
            unitOfWorkAsync.SaveChanges();            
        }
        public void Update(IUnitOfWorkAsync unitOfWorkAsync, CollectionForBazarAndInstallation Collection)
        {           
            _repository.Update(Collection);
            unitOfWorkAsync.SaveChanges();
        }
        public void Delete(int Id,IUnitOfWorkAsync unitOfWorkAsync)
        {
            CollectionForBazarAndInstallation Collection = new CollectionForBazarAndInstallation();
            Collection = GetCollectionById(Id);
            _repository.Delete(Collection);
            unitOfWorkAsync.SaveChanges();
        }
    }
}
