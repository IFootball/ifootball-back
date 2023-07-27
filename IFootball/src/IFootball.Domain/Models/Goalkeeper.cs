namespace IFootball.Domain.Models;

public class Goalkeeper : BaseEntity
{
    public int TakenGols { get; private set; }
    public int PenaltySaves { get; private set; }
    public int Saves { get; private set; }
    public long IdPlayer { get; private set; }
 
    public Player Player { get; set; }

    public Goalkeeper() { }
    public Goalkeeper(long idPlayer) 
    {
        IdPlayer = idPlayer;
        TakenGols = 0;
        PenaltySaves = 0;
        Saves = 0;
    }

}