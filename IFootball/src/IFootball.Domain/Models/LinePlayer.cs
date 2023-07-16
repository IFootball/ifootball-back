﻿namespace IFootball.Domain.Models;

public class LinePlayer : BaseEntity
{
    public Gender Gender { get; private set; }
    public long IdGender { get; private set; }

    public TeamClass TeamClass { get; private set; }
    public long IdTeamClass { get; private set; }

    public string Name { get; private set; }
    public string Image { get; private set; }
    public int Goals { get; private set; }
    public int Assists { get; private set; }
    public int YellowCard { get; private set; }
    public int RedCard { get; private set; }
    public int Fouls { get; private set; }
    public int Wins { get; private set; }
    
    public List<TeamUser> TeamUsersBackRight { get; set; }
    public List<TeamUser> TeamUsersBackLeft { get; set; }
    public List<TeamUser> TeamUsersFrontRight { get; set; }
    public List<TeamUser> TeamUsersFrontLeft { get; set; }

    public LinePlayer() { }
    
    public void Edit(long idGender, long idTeamClass, string name, string image)
    {
        IdGender = idGender;
        IdTeamClass = idTeamClass;
        Name = name;
        Image = image;
    }
    
    public LinePlayer(long idGender, long idTeamClass, string name, string image)
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
    }
}