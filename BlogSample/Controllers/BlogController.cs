using BlogSample.Core.Contracts.Service;
using BlogSample.Core.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace BlogSample.Controllers
{
    [Route("blog/{action}/{request?}")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet, ActionName("GetList")]
        [ResponseType(typeof(ICollection<BlogDto>))]
        public IActionResult GetBlogs()
        {
            var result = _blogService.GetBlogs();
            return Ok(result);
        }

        [HttpGet("{id}"), ActionName("Detail")]
        [ResponseType(typeof(BlogDto))]
        public IActionResult GetDetail(BlogId request)
        {
            if (request is null)
            {
                return BadRequest("Parameter is null.");
            }
            var result = _blogService.GetBlogDetail(request);
            return Ok(result);
        }
                
        [HttpPost, ActionName("Create")]
        public IActionResult CreateBlog([FromBody] BlogDto request)
        {
            if (request is null)
            {
                return BadRequest("Parameter is null.");
            }
            var result = _blogService.CreateBlog(request);
            return Ok(result);
        }

        [HttpPut, ActionName("Update")]
        public IActionResult UpdateBlog([FromBody] BlogDto request)
        {
            if (request is null)
            {
                return BadRequest("Parameter is null.");
            }
            var result = _blogService.UpdateBlog(request);
            return Ok(result);
        }

        [HttpDelete, ActionName("Detete")]
        public IActionResult DeleteBlog(BlogId request)
        {
            if (request is null)
            {
                return BadRequest("Parameter is null.");
            }
            var result = _blogService.DeleteBlog(request);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult SearchByRangeTime([FromBody] TimeRangeDto request)
        {
            if (request is null)
            {
                return BadRequest("Parameter is null.");
            }
            var result = _blogService.SearchByDatetimeRange(request);
            return Ok(result);
        }
    }
}
