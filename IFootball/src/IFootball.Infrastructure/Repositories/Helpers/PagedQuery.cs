using IFootball.Core;
using Microsoft.EntityFrameworkCore;

namespace IFootball.Infrastructure.Repositories.Helpers;

public static class PagedQuery
{
    public static async Task<PagedResponse<T>> GetPagedResponse<T>(IQueryable<T> query, Pageable pageable)
    {
        var players = await query
            .OrderBy(x => x.GetType().GetProperty(pageable.OrderBy).GetValue(x, null))
            .Skip(pageable.Offset())
            .Take(pageable.Take)
            .ToListAsync();
        
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageable.Take);
        var lastPage = pageable.Page >= totalPages;

        return new PagedResponse<T>(players, totalPages, totalCount, lastPage);
    }

}