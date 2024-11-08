using Microsoft.AspNetCore.Mvc;
using Verkefni_ASP.Data.Interfaces;
using Verkefni_ASP.Models;
using Verkefni_ASP.Models.DTOs;

namespace Verkefni_ASP.Controllers;

[Route("api/subjects")]
[Controller]
public class SubjectController : ControllerBase
{
    private readonly IRepository _repository;


    public SubjectController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task <ActionResult<List<SubjectDTO>>> GetAllSubjectsAsync()
    {
        try
        {
            List<Subject> subjects = await _repository.GetAllSubjectsAsync();
            var subjectDTOs = subjects.Select(s => new SubjectDTO
            {
                Id = s.Id,
                Title = s.Title,
            }).ToList();
            
            return Ok(subjectDTOs);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Subject>> GetSubjectById(int id)
    {
        try
        {
            Subject subject = await _repository.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(subject);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateSubject([FromBody] Subject subject)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateSubjectAsync(subject);
                return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
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
    public async Task<ActionResult<Subject>> UpdateSubject(int id,[FromBody] Subject subject)
    {
        try
        {
            Subject sub = await _repository.UpdateSubjectAsync(id, subject);

            if (sub == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetSubjectById), new { id = sub.Id }, subject);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Subject>> DeleteSubject(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteSubjectAsync(id);
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