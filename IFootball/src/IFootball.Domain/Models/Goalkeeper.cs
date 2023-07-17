namespace IFootball.Domain.Models;

public class Goalkeeper : Player
{  
    public int TakenGols  { get; private set; }
    public int PenaltySaves  { get; private set; }
    public int Saves  { get; private set; }
   
    public List<TeamUser>? TeamUsers { get; set; }
    
    public Goalkeeper() { }

     public Goalkeeper(long idGender,long idTeamClass, string name, string image) : base(idGender, idTeamClass, name, image)
    {
        TakenGols = 0;
        PenaltySaves = 0;
        Saves = 0;
    }
}