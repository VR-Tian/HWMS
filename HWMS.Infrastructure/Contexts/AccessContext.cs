using System;
using HWMS.DoMain.Models;
using HWMS.DoMain.Models.Access;
using HWMS.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HWMS.Infrastructure.Contexts
{
    public class AccessContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO 通过配置文件读取。
            // 定义要使用的数据库
            optionsBuilder.UseSqlServer("server=172.23.36.125;uid=sa;pwd=Ljt1994..;database=HWMSApp");
        }
    }
}
