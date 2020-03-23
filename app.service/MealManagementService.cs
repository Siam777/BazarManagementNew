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
    public interface IMealManagementService : IService<MealManagement>
    {
        //UserInfo NewUserInfo(int instituteId);       
        //<VmMonthlyActivatedUser> GetAll(int InstituteId,int MonthId,int Year);
        void Save(IUnitOfWorkAsync unitOfWorkAsync, IList<MealManagement> MealManagementList, int InstituteId);

        // UserInfo GetUserDetailsByPinOrMobile(string pin, string contactNo, int instituteId, int userTypeId);       
    }

    public class MealManagementService : Service<MealManagement>, IMealManagementService
    {
        private readonly IRepositoryAsync<MealManagement> _repository;
        //private readonly IImageService _imageService;
       // private readonly IUserInfoService _userInfoService;
        public MealManagementService(IRepositoryAsync<MealManagement> repository
           // IImageService imageService,
            //IUserInfoService userInfoService
           )
            : base(repository)
        {
            _repository = repository;
           // _imageService = imageService;
            //_userInfoService = userInfoService;
        }                                     
        public void Save(IUnitOfWorkAsync unitOfWorkAsync, IList<MealManagement> MealManageMentList,int InstituteId)
        {
            foreach(MealManagement obj in MealManageMentList)
            {
                if (obj.Id == 0)
                {
                    obj.InstituteId = InstituteId;
                    _repository.Insert(obj);
                }
                else
                {
                    obj.InstituteId = InstituteId;
                    _repository.Update(obj);
                }
            }
           
            unitOfWorkAsync.SaveChanges();          
        }               
    }
}
