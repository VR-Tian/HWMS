using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Interfaces.Oracle;

namespace HWMS.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly INavigationMenuRepository _NavigationMenuRepository;
        private readonly IUserRepository _Repository;
        private readonly IMapper _Mapper;
        public UserAppService(IUserRepository repository, IMapper mapper, INavigationMenuRepository navigationMenuRepository)
        {
            this._Repository = repository;
            this._Mapper = mapper;
            this._NavigationMenuRepository = navigationMenuRepository;
        }

        public void Dispose()
        {
            //this._Repository.Dispose();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return null;
            //return this._Repository.GetAll().ProjectTo<UserViewModel>(_Mapper.ConfigurationProvider).ToList();
        }

        public UserViewModel GetByInfo(LoginRequestDto req)
        {
            //var nvarQuery = _NavigationMenuRepository.GetAll().Where(w => w.ActionName == "123").FirstOrDefault();
            return this._Repository.GetAll().Where(t => t.UserName == req.Username && t.Passwork == req.Password).ProjectTo<UserViewModel>(_Mapper.ConfigurationProvider).FirstOrDefault();
        }

        public List<NavigationMenuViewModel> GetRolePermissionOfUser(int userid)
        {
            return _Repository.GetRolePermissionOfUser(userid).ProjectTo<NavigationMenuViewModel>(_Mapper.ConfigurationProvider).ToList();
        }

        public List<RoleViewModel> GetRoleOfUser(UserViewModel user)
        {
            return _Repository.GetRoleOfUser(user.Id).ProjectTo<RoleViewModel>(_Mapper.ConfigurationProvider).ToList();
        }



        public bool IsValid(LoginRequestDto req)
        {
            return false;
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