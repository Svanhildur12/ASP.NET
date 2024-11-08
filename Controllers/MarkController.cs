using Microsoft.AspNetCore.Mvc;
using Verkefni_ASP.Data.Interfaces;
using Verkefni_ASP.Models;
using Verkefni_ASP.Models.DTOs;

namespace Verkefni_ASP.Controllers;

[Route("api/marks")]
[Controller]

public class MarkController : ControllerBase
{
    private readonly IRepository _repository;

    public MarkController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Mark>>> GetMarks()
    {
        try
        {
            List<Mark> marks = await _repository.GetAllMarksAsync();
            return Ok(marks);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Mark>> GetMarkById(int id)
    {
        try
        {
            Mark mark = await _repository.GetMarkByIdAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mark);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

    }

    [HttpPost]
    public IActionResult CreateMark(Mark mark)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repository.CreateMark(mark);
                return CreatedAtAction(nameof(GetMarkById), new { markId = mark.MarkId }, mark);
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
    public async Task<ActionResult<Mark>> UpdateMarkAsync(int id, [FromBody] MarkDTO mark)
    {
      
        try
        {
            Mark m = await _repository.UpdateMarkAsync(id, mark);
            if (m == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetMarkById), new { id = m.MarkId }, mark);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Mark>> DeleteMark(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteMarkAsync(id);
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