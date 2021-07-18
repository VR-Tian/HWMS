using System;
using System.Linq;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Interfaces.Oracle;
using HWMS.DoMain.Models;
using HWMS.DoMain.Models.Access;
using HWMS.Infrastructure.Contexts;
using HWMS.Infrastructure.Contexts.OracleContext;

namespace HWMS.Infrastructure.Repository.Oracle
{
    public class NavigationRepository : Repository<NavigationMenu>, INavigationMenuRepository
    {
        public NavigationRepository(O_HWMSContext OrderContext) : base(OrderContext)
        {
            
        }
    }
}