using System.ComponentModel.DataAnnotations;
using Verkefni_ASP.Models;

namespace Verkefni_ASP.Models;

public class Subject
{
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
}