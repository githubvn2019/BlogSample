using BlogSample.Core.Domain;
using BlogSample.Core.Domain.Entity;
using System;
using System.Collections.Generic;

namespace BlogSample.Core.Contracts.Data.Repository
{
    public interface IBlogRepository : IRepository<BlogEnity>
    {
        ICollection<BlogEnity> GetListDefault(int number = 100);
        ICollection<BlogEnity> GetWithDateTimeRange(DateTime BeginDate, DateTime EndDate);
    }
}
