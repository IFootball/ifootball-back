namespace IFootball.Domain.Models;

public class Goalkeeper : BaseEntity
{
    public Gender Gender { get; private set; }
    public long IdGender { get; private set; }

    public TeamClass TeamClass { get; private set; }
    public long IdTeamClass { get; private set; }
    
    public int TakenGols  { get; private set; }
    public int PenaltySaves  { get; private set; }
    public int Saves  { get; private set; }

    public string Name { get; private set; }
    public string Image { get; private set; }
    public int Goals { get; private set; }
    public int Assists { get; private set; }
    public int YellowCard { get; private set; }
    public int RedCard { get; private set; }
    public int Fouls { get; private set; }
    public int Wins { get; private set; }
    
    public List<TeamUser> TeamUsers { get; set; }
    
    public Goalkeeper() { }

    public void Edit(long idGender, long idTeamClass, string name, string image)
    {
        IdGender = idGender;
        IdTeamClass = idTeamClass;
        Name = name;
        Image = image;
    }

    public Goalkeeper(long idGender,long idTeamClass, string name, string image)
    {
        IdGender = idGender;
        IdTeamClass = idTeamClass;
        Name = name;
        Image = image;

        Goals = 0;
        Assists =0;
        YellowCard = 0;
        RedCard = 0;
        Fouls = 0;
        Wins = 0;
        TakenGols = 0;
        PenaltySaves = 0;
        Saves = 0;
    }
}