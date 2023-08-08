namespace IFootball.Core;

public class Pageable
{
    public int Page { get; set; } = 0;
    public int Take { get; set; } = 10;

    public int Offset() => (Page - 1) * Take;
}