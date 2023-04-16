namespace Core.Entities;

public class Coach
{
    public int MembershipCardNum { get; set; }
    public string? Phone { get; set; }
    
    public int ClubId { get; set; }
    public Club? Club { get; set; }
    
    public int? InstructorCategoryId { get; set; }
    public InstructorCategory? InstructorCategory { get; set; }
    
    //Every coach is a sportsman on its own
    public Sportsman? Sportsman { get; set; }
    
    //List of sportsmen he coaches
    public ICollection<Sportsman>? Sportsmen { get; set; }
}