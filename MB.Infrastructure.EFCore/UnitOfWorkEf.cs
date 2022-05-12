using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBlogerContext db;

        public UnitOfWorkEf(MasterBlogerContext db)
        {
            this.db = db;
        }

        public void BeginTran()
        {
            db.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            db.SaveChanges();
            db.Database.CommitTransaction();
        }

        public void RollBack()
        {
            db.Database.RollbackTransaction();
        }
    }
}
