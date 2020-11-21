using System;
using System.Collections.Generic;

namespace HWMS.DoMain.Interfaces
{
    public interface IMemoryCache
    {
        void Set(string key, List<string> errors);
    }
}