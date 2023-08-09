﻿namespace IFootball.Domain.Models;

public class TeamClass : BaseEntity
{
    public Gender Gender { get; set; }
    public long IdGender { get; set; }


    public Class Class { get; set; }
    public long IdClass { get; set; }

    public List<Player> TeamClassPlayers { get; set; } = new List<Player>();

    public TeamClass() { }

    public TeamClass(long idGender, long idClass)
    {
        IdGender = idGender;
        IdClass = idClass;
    }

    public void Edit(long idGender, long idClass)
    {
        IdGender = idGender;
        IdClass = idClass;
    }
    
    public int GetScore()
    {
        var scorePlayer = TeamClassPlayers.Select(x => x.GetScore());
        return scorePlayer.Aggregate(0, (acc, x) => acc + x);
    }
}