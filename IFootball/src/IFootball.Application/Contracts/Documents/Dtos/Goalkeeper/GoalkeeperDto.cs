﻿namespace IFootball.Application.Contracts.Documents.Dtos;

public class GoalkeeperDto
{
    public long IdGender { get; set; }
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
}