﻿namespace IFootball.Domain.Models;

public class Goalkeeper : BaseEntity
{
    public Gender Gender { get; set; }
    public long IdGender { get; set; }

    public Class Class { get; set; }
    public long IdClass { get; set; }

    public TeamClass TeamClass { get; set; }
    public long IdTeamClass { get; set; }

    
    public int TakenGols  { get; set; }
    public int PenaltySaves  { get; set; }
    public int Saves  { get; set; }

    public string Name { get; set; }
    public string Image { get; set; }
    public int Goals { get; set; }
    public int Assists { get; set; }
    public int YellowCard { get; set; }
    public int RedCard { get; set; }
    public int Fouls { get; set; }
    public int Wins { get; set; }
    
    public List<TeamUser> TeamUsers { get; set; }

    public Goalkeeper() { }

}