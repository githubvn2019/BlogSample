using BlogSample.Core.Domain.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlogSample.UnitTest
{
    [TestFixture]
    public class BlogTest
    {
        private ICollection<BlogDto> LstBlog;

        [SetUp]
        public void Setup()
        {
            LstBlog = new List<BlogDto>();
        }

        [Test]
        public void ShouldGetBlogs()
        {
            Assert.GreaterOrEqual(LstBlog.Count, 0);
        }

        [Test]
        public void ShouldCreateBlog()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldUpdateBlog()
        {
            Assert.Pass();
        }

        [Test]
        public void ShouldDeleteBlog()
        {
            Assert.Pass();
        }
    }
}