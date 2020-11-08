using System;
using HWMS.DoMain.Models;
using HWMS.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HWMS.Infrastructure.Contexts
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO 通过配置文件读取。
            // 定义要使用的数据库
            optionsBuilder.UseSqlServer("server=192.168.225.135;uid=sa;pwd=Ljt1994..;database=HWMSApp");
        }
    }
}
