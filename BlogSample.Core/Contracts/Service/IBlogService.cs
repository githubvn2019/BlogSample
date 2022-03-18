using BlogSample.Core.Domain.DTO;
using System.Collections.Generic;

namespace BlogSample.Core.Contracts.Service
{
    public interface IBlogService
    {
        ICollection<BlogDto> GetBlogs();
        BlogDto GetBlogDetail(BlogId request);
        bool CreateBlog(BlogDto request);
        bool UpdateBlog(BlogDto request);
        bool DeleteBlog(BlogId request);
        ICollection<BlogDto> SearchByDatetimeRange(TimeRangeDto request);
    }
}
