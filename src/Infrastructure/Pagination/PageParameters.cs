namespace MaterialsExchangeAPI.Infrastructure.Pagination;

public class PageParameters
{
    const int maxPageSize = 10;
    private int _pageSize;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize)
                ? maxPageSize
                : value;
        }
    }
}
