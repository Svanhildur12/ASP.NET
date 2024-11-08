using System.ComponentModel.DataAnnotations;

namespace Verkefni_ASP.Models.DTOs;

public class StudentDTO
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
}