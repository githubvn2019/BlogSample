using System;

namespace BlogSample.Core.Domain.DTO
{
    public class BlogDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
