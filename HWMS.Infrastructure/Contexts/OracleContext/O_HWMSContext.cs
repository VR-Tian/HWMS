using System;
using HWMS.DoMain.Models;
using HWMS.DoMain.Models.Access;
using HWMS.Infrastructure.Mappings;
using HWMS.Infrastructure.Mappings.OracleMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HWMS.Infrastructure.Contexts.OracleContext
{
    public class O_HWMSContext : DbContext
    {
        public O_HWMSContext(IConfiguration configuration):base()
        {
            
        }
        // public DbSet<Order> Orders { get; set; }
        // public DbSet<User> Users { get; set; }
        // public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<RoleMenuPermission> RoleMenuPermissions { get; set; }
        public DbSet<NavigationMenu> NavigationMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NavigationMenuMap());
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //TODO 通过配置文件读取。
            // 定义要使用的数据库
            //Data Source=xxx:1521/orcl; User Id=xxx; password=xxx;Pooling=false;
            //Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.19.19.187)(PORT=6521))(CONNECT_DATA=(SERVICE_NAME=easa)));User ID=User;Password=Pass;
            optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=192.168.1.101)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=helowin)));User ID=admin;Password=Ljt1994;", option => { option.UseOracleSQLCompatibility("11"); });
        }
    }
}
