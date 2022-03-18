using AutoMapper;
using BlogSample.Core.Contracts;
using BlogSample.Core.Contracts.Data.Repository;
using BlogSample.Core.Contracts.Service;
using BlogSample.Core.Domain.DTO;
using BlogSample.Core.Domain.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogSample.Service.Services
{
    public class BlogService : BaseService, IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public BlogService(IServiceProvider serviceProvider, IMapper mapper) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
            _repository = _serviceProvider.GetRequiredService<IBlogRepository>();
        }

        public ICollection<BlogDto> GetBlogs()
        {
            var result = new List<BlogDto>();
            var entities = _repository.GetListDefault().ToList();
            if (entities.Count > 0)
            {
                result = _mapper.Map<ICollection<BlogDto>>(entities).ToList();
            }

            return result;
        }

        public BlogDto GetBlogDetail(BlogId request)
        {
            var blog = _repository.GetByKey(request.Id);
            var result = _mapper.Map<BlogDto>(blog);
            return result;
        }

        public bool CreateBlog(BlogDto request)
        {
            var result = false;
            try
            {
                var entity = _mapper.Map<BlogEnity>(request);
                entity.CreatedDate = DateTime.Now;                

                _repository.Add(entity);
                UnitOfWork.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                //Logging.Error(ex);                
            }
            return result;
        }
        public bool UpdateBlog(BlogDto request)
        {
            var result = false;
            try
            {
                var entity = _repository.GetByKey(request.Id);
                if (entity != null)
                {
                    var updateEntity = _mapper.Map<BlogEnity>(request);
                    updateEntity.CreatedDate = entity.CreatedDate;
                    updateEntity.UpdatedDate = DateTime.Now;

                    _repository.Update(updateEntity);
                    UnitOfWork.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Logging.Error(ex);                
            }
            return result;
        }
        public bool DeleteBlog(BlogId request)
        {
            var result = false;
            try
            {
                var entity = _repository.GetByKey(request.Id);
                if (entity != null)
                {
                    _repository.Delete(entity);
                    UnitOfWork.SaveChanges();
                }                
                result = true;
            }
            catch (Exception ex)
            {
                //Logging.Error(ex);                
            }
            return result;
        }

        public ICollection<BlogDto> SearchByDatetimeRange(TimeRangeDto request)
        {
            var result = new List<BlogDto>();
            var beginDate = request.StartDate;
            var endDate = request.EndDate;

            var entities = _repository.GetWithDateTimeRange(beginDate, endDate).ToList();
            if (entities.Count > 0)
            {
                result = _mapper.Map<ICollection<BlogDto>>(entities).ToList();
            }

            return result;
        }
    }
}
