using System.ComponentModel.DataAnnotations;

namespace Verkefni_ASP.Models;

public class Student
{
    public int StudentId { get; set; }
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(255)]
    public int GroupId { get; set; }
    
    public Group Group { get; set; } = new Group();
}