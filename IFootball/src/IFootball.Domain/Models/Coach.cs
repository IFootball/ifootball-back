namespace IFootball.Domain.Models;

public class Coach : BaseEntity
{
    public Class Class { get; set; }
    public long IdClass { get; set; }
    
    public Gender Gender { get; set; }
    public long IdGender { get; set; }

    public TeamClass TeamClass { get; set; }
    public long IdTeamClass { get; set; }

    public string Name { get; set; }
    public string Image { get; set; }
    
    public List<TeamUser> TeamUsers { get; set; }

    public Coach() { }
}