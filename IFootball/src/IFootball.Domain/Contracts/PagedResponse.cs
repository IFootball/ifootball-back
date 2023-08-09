namespace IFootball.Domain.Contracts;

public class PagedResponse<T>
{
    public IEnumerable<T> Data { get; private set; }
    public int TotalPage { get; private set; }
    public int TotalRegisters { get; private set; }
    public bool LastPage { get; private set; }

    public PagedResponse(IEnumerable<T> data, int totalPage, int totalRegisters, bool lastPage)
    {
        Data = data;
        TotalPage = totalPage;
        TotalRegisters = totalRegisters;
        LastPage = lastPage;
    }
    
    public PagedResponse<U> Map<U>(Func<T, U> converter)
    {
        var mappedData = Data.Select(converter).ToList();
        return new PagedResponse<U>(mappedData, TotalPage, TotalRegisters, LastPage);
    }
}