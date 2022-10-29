using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class EmployerApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/employers", Get) 
            .Produces<List<Employer>>(StatusCodes.Status200OK)
            .WithName("GetAlEmployers")
            .WithTags("Getters");
        app.MapGet("/employers/{id}", GetById) 
            .Produces<Employer>(StatusCodes.Status200OK)
            .WithName("GetEmployer")
            .WithTags("Getters");
        app.MapPost("/employers", Post) 
            .Accepts<Employer>("application/json")
            .Produces<List<Employer>>(StatusCodes.Status201Created)
            .WithName("InsertEmployer")
            .WithTags("Inserts");
        app.MapPut("/employers", Put) 
            .Accepts<Employer>("application/json")
            .WithName("UpdateEmployer")
            .WithTags("Updaters");
        app.MapDelete("/employers/{id}", Delete) 
            .WithName("DeleteEmployer")
            .WithTags("Deleters");

        app.MapGet("/professions/search/name/{query}", SearchByName)
            .Produces<List<Employer>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchEmployersByName")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(IEmployerControl control) =>
        Results.Ok(await control.GetEmployersAsync());
    
    private async Task<IResult> GetById(Guid id, IEmployerControl control) =>
        await control.GetEmployerDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] Employer entity, IEmployerControl control)
    {
        await control.InsertEmployerAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/employers/{entity.Id}", entity);
    }

    private async Task<IResult> Put([FromBody] Employer entity, IEmployerControl control)
    {
        await control.UpdateEmployerAsync(entity);
        await control.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(Guid id, IEmployerControl control)
    {
        await control.DeleteEmployerAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
    
    private async Task<IResult> SearchByName(string query, IEmployerControl control) =>
        await control.GetEmployersAsync(query) is IEnumerable<Employer> entities
            ? Results.Ok(entities)
            : Results.NotFound(Array.Empty<Employer>());
}