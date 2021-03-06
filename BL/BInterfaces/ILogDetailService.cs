﻿using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BInterfaces
{
    public interface ILogDetailService
    {
        void CreateOrUpdate(BLogDetail author);
        BLogDetail GetLog(int id);
        IEnumerable<BLogDetail> GetLogs();
        void DeleteLog(int id);
        void Dispose();
    }
}
