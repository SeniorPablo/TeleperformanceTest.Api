using TeleperformanceTest.Core.QueryFilters;
using System;

namespace TeleperformanceTest.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
