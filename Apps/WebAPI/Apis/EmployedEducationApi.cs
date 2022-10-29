using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class EmployedEducationApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/employedEducations", Get) 
            .Produces<List<EmployedEducation>>(StatusCodes.Status200OK)
            .WithName("GetAllEmployedEducations")
            .WithTags("Getters");
        app.MapGet("/employedEducations/search/employed/id/{employedId}", GetByEmployed) 
            .Produces<List<EmployedEducation>>(StatusCodes.Status200OK)
            .WithName("GetAllEducationsByEmployed")
            .WithTags("Getters");
        app.MapGet("/employedEducations/{id}", GetById) 
            .Produces<EmployedEducation>(StatusCodes.Status200OK)
            .WithName("GetEmployedEducation")
            .WithTags("Getters");
        app.MapPost("/employedEducations", Post) 
            .Accepts<EmployedEducation>("application/json")
            .Produces<List<EmployedEducation>>(StatusCodes.Status201Created)
            .WithName("InsertEmployedEducation")
            .WithTags("Inserts");
        app.MapDelete("/employedEducations/{id}", Delete) 
            .WithName("DeleteEmployedEducation")
            .WithTags("Deleters");
    }
    
    private async Task<IResult> Get(IEmployedEducationControl control) =>
        Results.Ok(await control.GetEmployedEducationsAsync());
    private async Task<IResult> GetByEmployed(Guid employedId, IEmployedEducationControl control) =>
        Results.Ok(await control.GetEducationsOfEmployedAsync(employedId));
    
    private async Task<IResult> GetById(Guid id, IEmployedEducationControl control) =>
        await control.GetEmployedEducationDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] EmployedEducation entity, IEmployedEducationControl control)
    {
        await control.InsertEmployedEducationAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/employedEducations/{entity.Id}", entity);
    }

    private async Task<IResult> Delete(Guid id, IEmployedEducationControl control)
    {
        await control.DeleteEmployedEducationAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
}