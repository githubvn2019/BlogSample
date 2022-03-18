using BlogSample.Core.Contracts.Data.Repository;
using BlogSample.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSample.Data.Repository
{
    public class BlogRepository : Repository<BlogEnity>, IBlogRepository
    {
        private readonly AppDbContext _dbContext;
        public BlogRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public ICollection<BlogEnity> GetListDefault(int number = 100)
        {
            return _dbContext.Blog.Take(number).ToList();
        }

        public ICollection<BlogEnity> GetWithDateTimeRange(DateTime beginDate, DateTime endDate)
        {
            return _dbContext.Blog.Where(s => s.CreatedDate >= beginDate && s.CreatedDate <= endDate).ToList();
        }
    }
}