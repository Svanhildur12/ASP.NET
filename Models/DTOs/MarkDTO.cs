namespace Verkefni_ASP.Models.DTOs;

public class MarkDTO
{
    public int MarkId { get; set; }
    public double Marks { get; set; } 
    public DateTime Date { get; set; } = DateTime.Now;
    
}