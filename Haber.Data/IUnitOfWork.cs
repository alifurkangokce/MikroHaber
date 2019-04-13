﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data
{
   public interface IUnitOfWork
    {
        void SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
