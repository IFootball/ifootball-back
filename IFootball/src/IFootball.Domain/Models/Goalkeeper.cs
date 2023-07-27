namespace IFootball.Domain.Models;

public class Goalkeeper : BaseEntity
{
    public int TakenGols { get; private set; }
    public int PenaltySaves { get; private set; }
    public int Saves { get; private set; }
    public long idPlayer { get; private set; }
 
    public Player Player { get; set; }

    public Goalkeeper() { }

}