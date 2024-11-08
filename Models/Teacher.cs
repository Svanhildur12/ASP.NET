using System.ComponentModel.DataAnnotations;
using Verkefni_ASP.Models;

namespace Verkefni_ASP.Models;

public class Teacher
{
    public int TeacherId { get; set; }
   [MaxLength(256)]
    public string FirstName { get; set; }
    [MaxLength(256)]
    public string LastName { get; set; }

    public List<Subject> Subjects { get; set; } = new List<Subject>();
}