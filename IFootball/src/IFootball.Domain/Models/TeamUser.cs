namespace IFootball.Domain.Models;

public class TeamUser : BaseEntity
{
    public User User { get; private set; }
    public long IdUser { get; private set; }
    
    public long? IdCaptain { get; private set; }
    
    public Gender Gender { get; private set; }
    public long IdGender { get; private set; }
    
    public long IdGoalkeeper { get; private set; }
    public Player Goalkeeper { get; private set; }
    
    public long IdPlayerOne { get; private set; }
    public Player PlayerOne { get; private set; }

    public long IdPlayerTwo { get; private set; }
    public Player PlayerTwo { get; private set; }

    public long IdPlayerThree { get; private set; }
    public Player PlayerThree { get; private set; }

    public long IdPlayerFour { get; private set; }
    public Player PlayerFour { get; private set; }

    public long? IdReservePlayerOne { get; private set; }
    public Player? ReservePlayerOne { get; private set; }
    public long? IdReservePlayerTwo { get; private set; }
    public Player? ReservePlayerTwo { get; private set; }
    
    
    public TeamUser() { }

    public void EditUser(long idUser)
    {
        IdUser = idUser;
    }

    public void EditGender(long idGender)
    {
        IdGender = idGender;
    }

    public void EditReplaceTeam(TeamUser teamUser)
    {
        IdCaptain = teamUser.IdCaptain;
        IdGoalkeeper = teamUser.IdGoalkeeper;
        IdPlayerOne = teamUser.IdPlayerOne;
        IdPlayerTwo = teamUser.IdPlayerTwo;
        IdPlayerThree= teamUser.IdPlayerThree;
        IdPlayerFour= teamUser.IdPlayerFour;
        IdReservePlayerOne = teamUser.IdReservePlayerOne;
        IdReservePlayerTwo = teamUser.IdReservePlayerTwo;
    }

    public TeamUser(long? idCaptain, long idGoalkeeper, long idPlayerOne, long idPlayerTwo, long idPlayerThree, long idPlayerFour, long? idReservePlayerOne, long? idReservePlayerTwo)
    {
        IdCaptain = idCaptain;
        IdGoalkeeper = idGoalkeeper;
        IdPlayerOne = idPlayerOne;
        IdPlayerTwo = idPlayerTwo;
        IdPlayerThree= idPlayerThree;
        IdPlayerFour= idPlayerFour;
        IdReservePlayerOne = idReservePlayerOne;
        IdReservePlayerTwo = idReservePlayerTwo;
    }
    
    public int GetScore()
    {
        var scorePlayer = new List<Player>();
        scorePlayer.Add(Goalkeeper);
        scorePlayer.Add(PlayerOne);
        scorePlayer.Add(PlayerTwo);
        scorePlayer.Add(PlayerThree);
        scorePlayer.Add(PlayerFour);
        
        if (ReservePlayerOne is not null)
            scorePlayer.Add(ReservePlayerOne);
        if (ReservePlayerTwo is not null)
            scorePlayer.Add(ReservePlayerTwo);
        
        return scorePlayer
            .Select(x => x.Id == IdCaptain ? 
                    (x.GetScore() * 2) : x.GetScore())
            .OrderByDescending(x => x)
            .Take(5)
            .Sum();
    }
}