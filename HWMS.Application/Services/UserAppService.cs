using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Interfaces;

namespace HWMS.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _Repository;
        private readonly IMapper _Mapper;
        public UserAppService(IUserRepository repository, IMapper mapper)
        {
            this._Repository = repository;
            this._Mapper = mapper;
        }

        public void Dispose()
        {
            this._Repository.Dispose();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return this._Repository.GetAll().ProjectTo<UserViewModel>(_Mapper.ConfigurationProvider).ToList();
        }

        public UserViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }
    }
}