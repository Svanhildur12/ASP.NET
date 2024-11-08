using Microsoft.AspNetCore.Mvc;
using Verkefni_ASP.Models;
using Verkefni_ASP.Data.Interfaces;
using Verkefni_ASP.Models.DTOs;

namespace Verkefni_ASP.Controllers;

[Route("api/teachers")]
[Controller]
public class TeacherController : ControllerBase
{
    private readonly IRepository _repository;

    public TeacherController(IRepository repository)
        {
            _repository = repository;
        }

    [HttpGet]
    public async Task <ActionResult<List<TeacherDTO>>> GetAllTeachers()
    {
        try
        {
            List<Teacher> teachers = await _repository.GetAllTeachersAsync();
            var teacherDTOs = teachers.Select(t => new TeacherDTO
            {
                TeacherId = t.TeacherId,
                FirstName = t.FirstName,
                LastName = t.LastName,
            }).ToList();
            
            return Ok(teacherDTOs);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacherById(int id)
    {
        try
        {
            Teacher teacher = await _repository.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(teacher);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }
    
    [HttpPost]
    public async Task<ActionResult> CreateTeacher([FromBody] Teacher teacher)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateTeacherAsync(teacher);
                // return Created("..", teacher);
                return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
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
    public async Task<ActionResult<Teacher>> UpdateTeacher(int id, [FromBody] Teacher teacher)
    {
        try
        {
            Teacher teach = await _repository.UpdateTeacherAsync(id, teacher);
            if (teach == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteTeacherAsync(id);
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