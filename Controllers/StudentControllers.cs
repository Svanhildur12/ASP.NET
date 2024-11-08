using Verkefni_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Verkefni_ASP.Data.Interfaces;
using Verkefni_ASP.Models.DTOs;

namespace Verkefni_ASP.Controllers;

[Route("api/students")]
[Controller]
public class StudentsController : ControllerBase
{
    private readonly IRepository _repository;


    public StudentsController(IRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public async Task <ActionResult<List<Student>>> GetAllStudents()
    {
        try
        {
            List<Student> students = await _repository.GetAllStudentsAsync();
            return Ok(students);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        try
        {
            // return _repository.GetStudentById(id);
            
            Student stud = await _repository.GetStudentByIdAsync(id);
            if (stud == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stud);
            }
            
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent([FromBody] Student student)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateStudentAsync(student);
                // return Created("..", student);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, student);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody] Student student)
    {
        try
        {
            Student stud = await _repository.UpdateStudentAsync(id, student);
            if (stud == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetStudentById), new { id = stud.StudentId }, stud);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteStudentAsync(id);
            if (!deleteSuccess)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
        
    }
}    