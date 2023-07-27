﻿using IFootball.Domain.Models.enums;

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
    
    public List<TeamUser>? TeamUsersFour { get; set; }
    public List<TeamUser>? TeamUsersThree { get; set; }
    public List<TeamUser>? TeamUsersTwo { get; set; }
    public List<TeamUser>? TeamUsersOne { get; set; }
    public List<TeamUser>? TeamUsersGoalkeeper { get; set; }
    public List<TeamUser>? TeamUsersReserveOne { get; set; }
    public List<TeamUser>? TeamUsersReserveTwo { get; set; }
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
}