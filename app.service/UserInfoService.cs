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
    public interface IUserInfoService : IService<UserInfo>
    {
        //UserInfo NewUserInfo(int instituteId);
        UserInfo GetUserById(int id);
        UserInfo GetUserAndInstituteInfoByUserId(int id);
        IEnumerable<VmUserInfo> GetAll(int InstituteId);
        VmUserInfo GetUserInfoByUserId(int UserId);
        // UserInfo GetUserDetailsByPinOrMobile(string pin, string contactNo, int instituteId, int userTypeId);
        UserInfo Insert(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo);
        void Update(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo);
        // IEnumerable<UserInfo> GetByMobileNumber(string mobileNumber, int instituteId);
    }

    public class UserInfoService:Service<UserInfo>, IUserInfoService
    {
        private readonly IRepositoryAsync<UserInfo> _repository;
        private readonly IImageService _imageService;
        public UserInfoService(IRepositoryAsync<UserInfo> repository,
            IImageService imageService
           )
            : base(repository)
        {
            _repository = repository;
            _imageService = imageService;
        }

        //public UserInfo NewUserInfo(int instituteId)
        //{
        //    var userInfo = new UserInfo();
        //    userInfo.IsActive = true;
        //    userInfo.GenderList =_genderService.GetGenderByInstituteId(instituteId).Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        //    userInfo.NationalityList = _nationalityService.GetNationalityByInstituteId(instituteId).Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        //    userInfo.ReligionList = _religionService.GetReligionByInstituteId(instituteId).Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        //    userInfo.BloodGroupList = _bloodGroupService.GetBloodGroupsByInstituteId(instituteId).Select(x=> new KeyValuePair<int,string>(x.Id,x.Name));
        //    //userInfo.RoleList= _roleService.GetRoles(instituteId, true).Select(r => new KeyValuePair<int, string>(r.Id, r.Name));
        //    return userInfo;
        //}

        public UserInfo GetUserById(int id)
        {
            var userInfo = _repository.Query(x => x.Id == id).Select().FirstOrDefault();
            return userInfo;
        }

        public UserInfo GetUserAndInstituteInfoByUserId(int id)
        {
            var userInfo = _repository.Query(x => x.Id == id)
                
                .Select().FirstOrDefault();
            return userInfo;
        }
        public IEnumerable<VmUserInfo> GetAll(int InstituteId)
        {
            var userInfo = _repository.Query(s=>s.InstituteId== InstituteId)
                .Select().ToList();
            IList<VmUserInfo> UserList = new List<VmUserInfo>();
            foreach (UserInfo item in userInfo)
            {
                var GetImage = _imageService.GetImageByUserId(item.Id);
                VmUserInfo vmUserInfo = new VmUserInfo();
                vmUserInfo.Id = item.Id;
                vmUserInfo.Name = item.Name;
                vmUserInfo.IsActive = item.IsActive;
                vmUserInfo.LastName = item.LastName;
                vmUserInfo.MiddleName = item.MiddleName;
                vmUserInfo.FirstName = item.FirstName;
                vmUserInfo.EmailAddress = item.EmailAddress;
                vmUserInfo.DOB = item.DOB;
                vmUserInfo.ContactNumber1 = item.ContactNumber1;
                vmUserInfo.ContactNumber2 = item.ContactNumber2;
                vmUserInfo.InstituteId = item.InstituteId;
                vmUserInfo.ImagePath = GetImage != null ? GetImage.ImagePath : null;
                UserList.Add(vmUserInfo);                
            }
            return UserList;
        }
        public VmUserInfo GetUserInfoByUserId(int UserId)
        {
            var userInfo = _repository.Query(s => s.Id == UserId)
                .Select().SingleOrDefault();
            var GetImage = _imageService.GetImageByUserId(UserId);
            VmUserInfo vmUserInfo = new VmUserInfo();
            vmUserInfo.Id = userInfo.Id;
            vmUserInfo.Name = userInfo.Name;
            vmUserInfo.IsActive = userInfo.IsActive;
            vmUserInfo.LastName = userInfo.LastName;
            vmUserInfo.MiddleName = userInfo.MiddleName;
            vmUserInfo.FirstName = userInfo.FirstName;
            vmUserInfo.EmailAddress = userInfo.EmailAddress;
            vmUserInfo.DOB = userInfo.DOB;
            vmUserInfo.ContactNumber1 = userInfo.ContactNumber1;
            vmUserInfo.ContactNumber2 = userInfo.ContactNumber2;
            vmUserInfo.InstituteId = userInfo.InstituteId;
            vmUserInfo.ImagePath = GetImage!=null? GetImage.ImagePath:null;
            return vmUserInfo;
        }
        public UserInfo Insert(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo)
        {
            _repository.Insert(userInfo);
            unitOfWorkAsync.SaveChanges();
            var result = _repository.Query().Select().LastOrDefault();
            return result;
        }
        public void Update(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo)
        {           
            _repository.Update(userInfo);
            unitOfWorkAsync.SaveChanges();

        }
        //public UserInfo GetUserDetailsByPinOrMobile(string pin, string contactNo, int instituteId, int userTypeId)
        //{
        //    var predicate = PredicateBuilder.True<UserInfo>();
        //    predicate = predicate.And(p => p.IsActive && p.InstituteId == instituteId && p.UserInfoTypeId == userTypeId);

        //    if (pin != null)
        //        predicate = predicate.And(p => p.PIN == pin);

        //    if (contactNo != null)
        //        predicate = predicate.And(p => p.ContactNumber1 == contactNo || p.ContactNumber2 == contactNo);

        //    return _repository.Query(predicate).Select().FirstOrDefault();

        //}

        //public IEnumerable<UserInfo> GetByMobileNumber(string mobileNumber, int instituteId)
        //{
        //    return _repository.Query(x => x.InstituteId==instituteId
        //        &&(x.ContactNumber1 == mobileNumber || x.ContactNumber2 == mobileNumber))
        //        .Include(x => x.UserInfoSecurity)                
        //        .Select()
        //        ;
        //}
    }
}
