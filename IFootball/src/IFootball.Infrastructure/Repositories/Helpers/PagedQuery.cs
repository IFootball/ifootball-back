using IFootball.Core;
using Microsoft.EntityFrameworkCore;

namespace IFootball.Infrastructure.Repositories.Helpers;

public static class PagedQuery
{
    public static async Task<PagedResponse<T>> GetPagedResponse<T>(IQueryable<T> query, Pageable pageable)
    {
        var data = await query
            .Skip(pageable.Offset())
            .Take(pageable.Take)
            .ToListAsync();
        
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageable.Take);
        var lastPage = pageable.Page >= totalPages;

        return new PagedResponse<T>(data, totalPages, totalCount, lastPage);
    }

}