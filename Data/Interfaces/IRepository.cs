using Verkefni_ASP.Models;
using Verkefni_ASP.Models.DTOs;

namespace Verkefni_ASP.Data.Interfaces;
public interface IRepository
{
    Task <List<Student>> GetAllStudentsAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task <List<Subject>> GetAllSubjectsAsync();
    Task<Subject> GetSubjectByIdAsync(int id);
    Task CreateStudentAsync(Student student);
    Task CreateSubjectAsync(Subject subject);
    Task <Subject> UpdateSubjectAsync(int id,Subject subject);
    Task<Student> UpdateStudentAsync(int id,Student student);
    Task<bool> DeleteStudentAsync(int id);
    Task <bool> DeleteSubjectAsync(int id);
    Task<List<Teacher>> GetAllTeachersAsync();
    Task<Teacher> GetTeacherByIdAsync(int id);
    Task CreateTeacherAsync(Teacher teacher);
    Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher);
    Task<bool> DeleteTeacherAsync(int id);
    Task <List<Mark>> GetAllMarksAsync();
    Task<Mark> GetMarkByIdAsync(int id);
    void CreateMark(Mark mark);
    Task<Mark> UpdateMarkAsync(int id, MarkDTO mark);
    Task<bool> DeleteMarkAsync(int id);
}