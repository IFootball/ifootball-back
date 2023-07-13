namespace IFootball.Domain.Models;

public class TeamUser : BaseEntity
{
    public User User { get; private set; }
    public long IdUser { get; private set; }
    
    public long? IdCaptain { get; private set; }
    
    public Gender Gender { get; private set; }
    public long IdGender { get; private set; }
    
    public Goalkeeper Goalkeeper { get; private set; }
    public long IdGoalkeeper { get; private set; }
    
    public long IdLinePlayerFront { get; private set; }
    public LinePlayer LinePlayerFront { get; private set; }

    public long IdLinePlayerMiddle { get; private set; }
    public LinePlayer LinePlayerMiddle { get; private set; }

    public long IdLinePlayerBackRight { get; private set; }
    public LinePlayer LinePlayerBackRight { get; private set; }

    public long IdLinePlayerBackLeft { get; private set; }
    public LinePlayer LinePlayerBackLeft { get; private set; }

    public long? IdReservePlayerOne { get; private set; }
    public LinePlayer? ReservePlayerOne { get; private set; }
    public long? IdReservePlayerTwo { get; private set; }
    public LinePlayer? ReservePlayerTwo { get; private set; }
    
    
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
        IdLinePlayerFront = teamUser.IdLinePlayerFront;
        IdLinePlayerMiddle = teamUser.IdLinePlayerMiddle;
        IdLinePlayerBackRight = teamUser.IdLinePlayerBackRight;
        IdLinePlayerBackLeft = teamUser.IdLinePlayerBackLeft;
        IdReservePlayerOne = teamUser.IdReservePlayerOne;
        IdReservePlayerTwo = teamUser.IdReservePlayerTwo;
    }

    public TeamUser(long? idCaptain, long idGoalkeeper, long idLinePlayerFront, long idLinePlayerMiddle, long idLinePlayerBackRight, long idLinePlayerBackLeft, long? idReservePlayerOne, long? idReservePlayerTwo)
    {
        IdCaptain = idCaptain;
        IdGoalkeeper = idGoalkeeper;
        IdLinePlayerFront = idLinePlayerFront;
        IdLinePlayerMiddle = idLinePlayerMiddle;
        IdLinePlayerBackRight = idLinePlayerBackRight;
        IdLinePlayerBackLeft = idLinePlayerBackLeft;
        IdReservePlayerOne = idReservePlayerOne;
        IdReservePlayerTwo = idReservePlayerTwo;
    }
    
}