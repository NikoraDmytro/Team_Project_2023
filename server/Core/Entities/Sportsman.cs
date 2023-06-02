namespace Core.Entities;

public enum Sex
{
    M,
    F
}

public class Sportsman
{
    public int MembershipCardNum { get; set; }
    public DateTime BirthDate { get; set; }
    public Sex Sex { get; set; }

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public int? CoachMembershipCardNum { get; set; }
    public virtual Coach? Coach { get; set; }

    public int BeltId { get; set; }
    public virtual Belt? Belt { get; set; }
    
    public int? SportsCategoryId { get; set; }
    public virtual SportsCategory? SportsCategory { get; set; }
}