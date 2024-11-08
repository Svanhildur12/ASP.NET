namespace Verkefni_ASP.Models;

public class Mark
{

    public int MarkId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public double Marks { get; set; } 
    
    public Student Student { get; set; } = new Student();
    public Subject Subject { get; set; } = new Subject();
}