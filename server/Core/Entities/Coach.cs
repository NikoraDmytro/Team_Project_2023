namespace Core.Entities;

public class Coach
{
    public int MembershipCardNum { get; set; }
    public string? Phone { get; set; }
    
    public int ClubId { get; set; }
    public virtual Club? Club { get; set; }
    
    public int InstructorCategoryId { get; set; }
    public virtual InstructorCategory? InstructorCategory { get; set; }
    
    //Every coach is a sportsman on its own
    public virtual Sportsman? Sportsman { get; set; }
    
    //List of sportsmen he coaches
    public virtual ICollection<Sportsman>? Sportsmen { get; set; }
}