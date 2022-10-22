using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/profession")]
public class ProfessionController : Controller
{
    private readonly ApplicationContext _dbContext;

    public ProfessionController(ApplicationContext dbContext) => _dbContext = dbContext;
    
    [HttpGet]
    public Task<ActionResult> GetProfessions()
    {
        return Task.FromResult<ActionResult>(Ok(_dbContext.Professions!.ToList()));
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult> GetProfessions([FromRoute] int id)
    {
        var profession = await _dbContext.Professions!.FindAsync(id);

        if (profession != null) return Ok(profession);
        
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> InsertProfession(Profession profession)
    {
        await _dbContext.Professions!.AddAsync(profession);
        await _dbContext.SaveChangesAsync();

        return Ok(profession);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfession(Profession? profession)
    {
        if (profession?.Id != null)
        {
            var updatingProfession = await _dbContext.Professions!.FindAsync(profession.Id);
            updatingProfession!.Name = profession.Name;
            await _dbContext.SaveChangesAsync();
            
            return Ok(profession);
        }

        return NotFound();
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteProfession([FromRoute] int id)
    {
        var profession = await _dbContext.Professions!.FindAsync(id);

        if (profession == null) return NotFound();

        _dbContext.Remove(profession);
        await _dbContext.SaveChangesAsync();
        
        return Ok(profession);
    }
}