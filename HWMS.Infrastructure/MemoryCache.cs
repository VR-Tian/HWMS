using System;
using System.Collections.Generic;
using System.Linq;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models;
using HWMS.Infrastructure.Contexts;

namespace HWMS.Infrastructure
{
    public class MemoryCache : IMemoryCache
    {
        public void Set(string key, List<string> errors)
        {
            // throw new NotImplementedException();
        }
    }
}