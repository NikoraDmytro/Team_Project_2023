using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Club
{
    [Key]
    [Column("club_id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Club name is required!")]
    [MaxLength(120, ErrorMessage = "Maximum length for club name is 120 characters!")]
    [Column("name", TypeName = "varchar(120)")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Club city is required!")]
    [MaxLength(100, ErrorMessage = "Maximum length for club city is 100 characters!")]
    [Column("city", TypeName = "varchar(100)")]
    public string? City { get; set; }
    
    [Required(ErrorMessage = "Club address is required!")]
    [MaxLength(200, ErrorMessage = "Maximum length for club address is 200 characters!")]
    [Column("address", TypeName = "varchar(200)")]
    public string? Address { get; set; }
}