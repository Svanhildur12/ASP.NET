using System.ComponentModel.DataAnnotations;

namespace Verkefni_ASP.Models.DTOs;

public class TeacherDTO
{
    public int TeacherId { get; set; }
    [MaxLength(256)]
    public string FirstName { get; set; }
    [MaxLength(256)]
    public string LastName { get; set; }
}