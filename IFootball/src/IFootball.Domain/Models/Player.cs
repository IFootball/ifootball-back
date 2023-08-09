using System.Net.Sockets;
using IFootball.Domain.Models.enums;

namespace IFootball.Domain.Models;

public class Player : BaseEntity
{
    public Gender Gender { get; private set; }
    public long IdGender { get; private set; }

    public TeamClass TeamClass  { get; private set; }
    public long IdTeamClass { get; private set; }

    public PlayerType PlayerType { get; set; }
    public string Name { get; private set; }
    public string Image { get; private set; }
    public int Goals { get; private set; }
    public int Assists { get; private set; }
    public int YellowCard { get; private set; }
    public int RedCard { get; private set; }
    public int Fouls { get; private set; }
    public int Wins { get; private set; }

    public List<TeamUser>? TeamUsersFour { get; set; } = new List<TeamUser>();
    public List<TeamUser>? TeamUsersThree { get; set; } = new List<TeamUser>();
    public List<TeamUser>? TeamUsersTwo { get; set; } = new List<TeamUser>();
    public List<TeamUser>? TeamUsersOne { get; set; } = new List<TeamUser>();
    public List<TeamUser>? TeamUsersGoalkeeper { get; set; } = new List<TeamUser>();
    public List<TeamUser>? TeamUsersReserveOne { get; set; } = new List<TeamUser>();
    public List<TeamUser>? TeamUsersReserveTwo { get; set; } = new List<TeamUser>();
    public Goalkeeper? Goalkeeper { get; set; }
    
    
    public Player() { }
        
    public Player(long idGender, long idTeamClass, string name, string image, PlayerType playerType)
    {
        IdGender = idGender;
        IdTeamClass = idTeamClass;
        Name = name;
        Image = image;
        PlayerType = playerType;
        
        Goals = 0;
        Assists =0;
        YellowCard = 0;
        RedCard = 0;
        Fouls = 0;
        Wins = 0;
    }
    public void Edit(long idGender, long idTeamClass, string name, string image)
    {
        IdGender = idGender;
        IdTeamClass = idTeamClass;
        Name = name;
        Image = image;
    }

    public int GetScore()
    {
        var score = (Assists * 5) + (Goals * 8) + (YellowCard * -2) + (RedCard * -4) + (Fouls * -1) + (Wins * 1);
        
        if (PlayerType == PlayerType.Goalkeeper)
            score += (Goalkeeper.Saves * 2) + (Goalkeeper.PenaltySaves * 8) + (Goalkeeper.TakenGols == 0 ? 8 : 0);

        if (score < 0) return 0;
        return score;
    }
}