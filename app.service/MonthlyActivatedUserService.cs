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
    public interface IMonthlyActivatedUserService : IService<MonthlyActivatedUser>
    {
        //UserInfo NewUserInfo(int instituteId);       
        IEnumerable<VmMonthlyActivatedUser> GetAll(int InstituteId,int MonthId,int Year);
        void Save(IUnitOfWorkAsync unitOfWorkAsync, IList<MonthlyActivatedUser> MonthlyActivatedUser, int InstituteId);

        // UserInfo GetUserDetailsByPinOrMobile(string pin, string contactNo, int instituteId, int userTypeId);       
    }

    public class MonthlyActivatedUserService : Service<MonthlyActivatedUser>, IMonthlyActivatedUserService
    {
        private readonly IRepositoryAsync<MonthlyActivatedUser> _repository;
        private readonly IImageService _imageService;
        private readonly IUserInfoService _userInfoService;
        public MonthlyActivatedUserService(IRepositoryAsync<MonthlyActivatedUser> repository,
            IImageService imageService,
            IUserInfoService userInfoService
           )
            : base(repository)
        {
            _repository = repository;
            _imageService = imageService;
            _userInfoService = userInfoService;
        }                       
        public IEnumerable<VmMonthlyActivatedUser> GetAll(int InstituteId,int MonthId,int Year)
        {
            var userInfo = _repository.Query(s=>s.InstituteId== InstituteId && s.MonthId==MonthId && s.Year==Year)
                .Select().ToList();
            IList<VmMonthlyActivatedUser> UserList = new List<VmMonthlyActivatedUser>();
            if (userInfo.Count > 0)
            {
                foreach (MonthlyActivatedUser item in userInfo)
                {
                    var GetImage = _imageService.GetImageByUserId(item.UserId);
                    var GetUserInfo = _userInfoService.GetUserById(item.UserId);
                    VmMonthlyActivatedUser vmUserInfo = new VmMonthlyActivatedUser();
                    vmUserInfo.Id = item.Id;
                    vmUserInfo.UserId = item.UserId;
                    vmUserInfo.Name = GetUserInfo.Name;
                    vmUserInfo.IsActive = item.IsActive;
                    vmUserInfo.InstituteId = item.InstituteId;
                    vmUserInfo.MonthId = item.MonthId;
                    vmUserInfo.Year = item.Year;
                    vmUserInfo.ImagePath = GetImage != null ? GetImage.ImagePath : null;
                    UserList.Add(vmUserInfo);
                }
            }
            return UserList;
        }
       
        public void Save(IUnitOfWorkAsync unitOfWorkAsync, IList<MonthlyActivatedUser> MonthlyActivatedUser,int InstituteId)
        {
            foreach(MonthlyActivatedUser obj in MonthlyActivatedUser)
            {
                if (obj.Id == 0)
                {
                    obj.InstituteId = InstituteId;
                    _repository.Insert(obj);
                }
                else
                {
                    _repository.Update(obj);
                }
            }
           
            unitOfWorkAsync.SaveChanges();          
        }               
    }
}
