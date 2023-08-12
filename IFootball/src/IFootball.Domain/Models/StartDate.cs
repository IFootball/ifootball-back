namespace IFootball.Domain.Models;

public class StartDate : BaseEntity
{
    public DateTime StartDateOfMatches { get; set; }

    public StartDate(DateTime startDateOfMatches)
    {
        StartDateOfMatches = startDateOfMatches;
    }
}