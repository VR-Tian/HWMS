using System;
using HWMS.DoMain.Models;
using HWMS.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HWMS.Infrastructure.Contexts
{
    public class HWMSContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO 通过配置文件读取。
            // 定义要使用的数据库
            optionsBuilder.UseSqlServer("server=172.29.107.79;uid=sa;pwd=Ljt1994..;database=HWMSApp");
        }
    }
}
