using System;
using HWMS.DoMain.Interfaces;
using HWMS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HWMS.Infrastructure
{
    /// <summary>
    /// 工作单元类
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //数据库上下文
        private readonly HWMSContext _context;

        //构造函数注入
        public UnitOfWork(HWMSContext context)
        {
            _context = context;
        }

        //上下文提交
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        //手动回收
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}