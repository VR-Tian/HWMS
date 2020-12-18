using System;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models.Access;
using HWMS.Infrastructure.Contexts;

namespace HWMS.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AccessContext accessContext) : base(accessContext)
        {
            
        }
    }
}