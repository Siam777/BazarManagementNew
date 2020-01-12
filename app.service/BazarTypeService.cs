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
    public interface IBazarTypeService : IService<BazarType>
    {
        List<KeyValuePair<int, string>> GetKVP();
    }

    public class BazarTypeService:Service<BazarType>, IBazarTypeService
    {
        private readonly IRepositoryAsync<BazarType> _repository;
       
        public BazarTypeService(IRepositoryAsync<BazarType> repository           
           )
            : base(repository)
        {
            _repository = repository;
            
        }
        public List<KeyValuePair<int, string>> GetKVP()
        {
            var data = _repository.Query().Select().ToList();
            var BazarTypeList = new List<KeyValuePair<int, string>>();
            data.ForEach(c => BazarTypeList.Add(new KeyValuePair<int, string>(c.Id, c.Name)));
            return BazarTypeList;
        }

    }
}
