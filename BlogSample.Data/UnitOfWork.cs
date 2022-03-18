using BlogSample.Core.Domain;
using System;

namespace BlogSample.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext dbContext { get; }
        private bool _disposed;

        public UnitOfWork(AppDbContext ctx)
        {
            this.dbContext = ctx;
        }

        /// <summary>
        /// Execute pending changes 
        /// </summary>
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                dbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
