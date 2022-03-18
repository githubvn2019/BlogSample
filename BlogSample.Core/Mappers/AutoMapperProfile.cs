using AutoMapper;
using BlogSample.Core.Domain.DTO;
using BlogSample.Core.Domain.Entity;

namespace BlogSample.Core.Mappers
{
    public sealed partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogEnity, BlogDto>().ReverseMap();
        }
    }
}
