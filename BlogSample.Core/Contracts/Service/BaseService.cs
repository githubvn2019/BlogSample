using BlogSample.Core.Domain;
using System;
using Microsoft.Extensions.DependencyInjection;
namespace BlogSample.Core.Contracts
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected BaseService(IServiceProvider serviceProvider)
        {
            UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
