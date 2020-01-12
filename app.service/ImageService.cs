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

namespace app.Service
{
    public interface IImageService : IService<Image>
    {
        //UserInfo NewUserInfo(int instituteId);
        Image GetImageById(int id);
        //UserInfo GetUserAndInstituteInfoByUserId(int id);
        Image GetImageByUserId(int? UserId);
        void SaveImage(Image image,IUnitOfWorkAsync _unitOfWorkAsync);
        //IEnumerable<UserInfo> GetAll(int InstituteId);        
        // UserInfo GetUserDetailsByPinOrMobile(string pin, string contactNo, int instituteId, int userTypeId);
        //void Insert(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo);
        //void Update(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo);
        // IEnumerable<UserInfo> GetByMobileNumber(string mobileNumber, int instituteId);
    }

    public class ImageService:Service<Image>, IImageService
    {
        private readonly IRepositoryAsync<Image> _repository;               
        public ImageService(IRepositoryAsync<Image> repository
          
           )
            : base(repository)
        {
            _repository = repository;
            
        }
        public Image GetImageById(int id)
        {
            var image = _repository.Query(x => x.Id == id).Select().FirstOrDefault();
            return image;
        }
        public Image GetImageByUserId(int? UserId)
        {
            var image = _repository.Query(x => x.UserId == UserId).Select().FirstOrDefault();
            return image;
        }
        //public IEnumerable<Image> GetAll(int InstituteId)
        //{
        //    var ImageInfo = _repository.Query(s=>s.InstituteId== InstituteId)
        //        .Select().ToList();
        //    return ImageInfo;
        //}
        //public void Insert(IUnitOfWorkAsync unitOfWorkAsync, UserInfo userInfo)
        //{
        //    _repository.Insert(userInfo);
        //    unitOfWorkAsync.SaveChanges();
        //}

        public void SaveImage(Image image,IUnitOfWorkAsync _unitOfWorkAsync)
        {
            try
            {
                int? UserId = image.UserId != null ? image.UserId : 0;
                Image checkImage = new Image();
                checkImage = GetImageByUserId(UserId);
                if (checkImage == null)
                {
                    _repository.Insert(image);
                }

                else
                {
                    checkImage.ImageBinaryData = image.ImageBinaryData;
                    checkImage.ImagePath = image.ImagePath;
                   // image.Id = checkImage.Id;
                    _repository.Update(checkImage);
                }
               
                _unitOfWorkAsync.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
