using Microsoft.EntityFrameworkCore;
using Verkefni_ASP.Models;
using Verkefni_ASP.Data.Interfaces;
using Verkefni_ASP.Models.DTOs;

namespace Verkefni_ASP.Data.Repository;

public class SchoolRepository : IRepository
{
    private readonly SchoolDbContext _dbContext = new();
    private IRepository _repositoryImplementation;

    public async Task CreateSubjectAsync(Subject subject)
    {
        using (var db = _dbContext)
        {
            await db.Subjects.AddAsync(subject);
            await db.SaveChangesAsync();
        }
    }
    public async Task<Subject> UpdateSubjectAsync(int id, Subject subject)
    {
        Subject subjectToUpdate;
        using (var db = _dbContext)
        {
            subjectToUpdate = await db.Subjects.FirstOrDefaultAsync(x => x.Id == id);
            if (subjectToUpdate == null)
            {
                return null;
            }
            subjectToUpdate.Title = subject.Title;
            await db.SaveChangesAsync();

            return subjectToUpdate;
        }
    }
    public async Task<Student> UpdateStudentAsync(int id, Student student)
    {
        Student studentToUpdate;
        
        using (var db = _dbContext)
        {
            studentToUpdate = await db.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            
            if (studentToUpdate == null)
            {
                return null;
            }
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            
            await db.SaveChangesAsync();

            return studentToUpdate;
        }
    }
    public async Task<bool> DeleteStudentAsync(int id)
    {
        Student studentToDelete;

        using (var db = _dbContext)
        {
            studentToDelete = await db.Students.FirstOrDefaultAsync(s => s.StudentId == id);

            if (studentToDelete == null)
            {
                return false;
            }
            else
            {
                db.Students.Remove(studentToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
    public async Task <bool> DeleteSubjectAsync(int id)
    {
        Subject subjectToDelete;

        using (var db = _dbContext)
        {
            subjectToDelete = await db.Subjects.FirstOrDefaultAsync(s => s.Id == id);

            if (subjectToDelete == null)
            {
                return false;
            }
            else
            {
                db.Subjects.Remove(subjectToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
    public Task<List<Teacher>> GetAllTeachersAsync()
    {
        using (var db = _dbContext)
        {
            return db.Teachers.ToListAsync();
        }
    }
    public async Task<Teacher> GetTeacherByIdAsync(int id)
    {
        Teacher teacher;
        using (var db = _dbContext)
        {
            teacher = await db.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
        }
        return teacher;
    }
    public async Task CreateTeacherAsync(Teacher teacher)
    {
        using (var db = _dbContext)
        {
            await db.Teachers.AddAsync(teacher);
            await db.SaveChangesAsync();
        }
    }
    public async Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher)
    {
        Teacher teacherToUpdate;

        using (var db = _dbContext)
        {
            teacherToUpdate = await db.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);

            if (teacherToUpdate == null)
            {
                return null;
            }
            teacherToUpdate.FirstName = teacher.FirstName;
            teacherToUpdate.LastName = teacher.LastName;

            await db.SaveChangesAsync();

            return teacherToUpdate;
        }
    }
    public async Task<bool> DeleteTeacherAsync(int id)
    {
        Teacher teacherToDelete;

        using (var db = _dbContext)
        {
            teacherToDelete = await db.Teachers.FirstOrDefaultAsync(t => t.TeacherId == id);

            if (teacherToDelete == null)
            {
                return false;
            }
            else
            {
                db.Teachers.Remove(teacherToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
    public Task<List<Mark>> GetAllMarksAsync()
    {
        using (var db = _dbContext)
        {
            return db.Marks.ToListAsync();
        }
    }
    public async Task<Mark> GetMarkByIdAsync(int id)
    {
        Mark mark;
        using (var db = _dbContext)
        {
            mark = await db.Marks.FirstOrDefaultAsync(t => t.MarkId == id);
        }

        return mark;
    }
    public void CreateMark(Mark mark)
    {
        using (var db = _dbContext)
        {
            db.Marks.Add(mark);
            db.SaveChanges();
        }
    }
    public async Task<Mark> UpdateMarkAsync(int id, MarkDTO mark)
    {
            Mark markToUpdate;
            using (var db = _dbContext)
            {
                markToUpdate = await db.Marks.FirstOrDefaultAsync(x => x.MarkId == id);
                if (markToUpdate == null)
                {
                    return null;
                }

                markToUpdate.Marks = mark.Marks;
                markToUpdate.Date = mark.Date;
                await db.SaveChangesAsync();

                return markToUpdate;
            }
    }
    public async Task<bool> DeleteMarkAsync(int id)
    {
        Mark markToDelete;
        using (var db = _dbContext)
        {
            markToDelete = await db.Marks.FirstOrDefaultAsync(m => m.MarkId == id);
            if (markToDelete == null)
            {
                return false;
            }
            else
            {
                db.Marks.Remove(markToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
        
    }
    public async Task CreateStudentAsync(Student student)
    {
        using (var db = _dbContext)
        {
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
        }
    }
    public Task<List<Subject>> GetAllSubjectsAsync()
    {
        using (var db = _dbContext)
        {
             return db.Subjects.ToListAsync();
        }

        
    }
    public async Task<Subject> GetSubjectByIdAsync(int id)
    {
            Subject s;
            using (var db = _dbContext)
            {
                s =  await db.Subjects.Include(t => t.Teachers).FirstOrDefaultAsync(x => x.Id == id);
            }
           
            return s;
        
    }
    public Task<List<Student>> GetAllStudentsAsync()
    {
        using (var db = _dbContext)
        {
            return db.Students.ToListAsync();
        }
    }
    public async Task<Student> GetStudentByIdAsync(int id)
    {
        Student s;
        
        using (var db = _dbContext)
        {
            
            s = await db.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            
        }
        
        return s;
    }
   
}