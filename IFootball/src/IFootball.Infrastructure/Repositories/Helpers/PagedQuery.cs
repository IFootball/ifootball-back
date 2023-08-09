using IFootball.Core;
using IFootball.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IFootball.Infrastructure.Repositories.Helpers;

public static class PagedQuery
{
    public static async Task<PagedResponse<T>> GetPagedResponse<T>(IEnumerable<T> query, Pageable pageable)
    {
        var data = query
            .Skip(pageable.Offset())
            .Take(pageable.Take)
            .ToList();
        
        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageable.Take);
        var lastPage = pageable.Page >= totalPages;

        return new PagedResponse<T>(data, totalPages, totalCount, lastPage);
    }

}