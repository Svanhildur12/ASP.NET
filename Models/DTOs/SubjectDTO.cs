using System.ComponentModel.DataAnnotations;

namespace Verkefni_ASP.Models.DTOs;

public class SubjectDTO
{
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
}