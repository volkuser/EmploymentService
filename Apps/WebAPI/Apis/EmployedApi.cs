using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class EmployedApi : IApi
{
        public void Register(WebApplication app)
    {
        app.MapGet("/employeds", Get) 
            .Produces<List<Employed>>(StatusCodes.Status200OK)
            .WithName("GetAllEmployeds")
            .WithTags("Getters");
        app.MapGet("/employeds/{sexId}", GetBySex) 
            .Produces<Employed>(StatusCodes.Status200OK)
            .WithName("GetAllEmployedsBySingleSex")
            .WithTags("Getters");
        app.MapGet("/employeds/{id}", GetById) 
            .Produces<Employed>(StatusCodes.Status200OK)
            .WithName("GetEmployed")
            .WithTags("Getters");
        app.MapPost("/employeds", Post) 
            .Accepts<Employed>("application/json")
            .Produces<List<Employed>>(StatusCodes.Status201Created)
            .WithName("InsertEmployed")
            .WithTags("Inserts");
        app.MapPut("/employeds", Put) 
            .Accepts<Employed>("application/json")
            .WithName("UpdateEmployed")
            .WithTags("Updaters");
        app.MapDelete("/employeds/{id}", Delete) 
            .WithName("DeleteEmployed")
            .WithTags("Deleters");

        app.MapGet("/employeds/search/{query}", SearchByQuery)
            .Produces<List<Profession>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchEmployedByQuery")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(IEmployedControl control) =>
        Results.Ok(await control.GetEmployedsAsync());
    private async Task<IResult> GetBySex(char sexId, IEmployedControl control) =>
        Results.Ok(await control.GetEmployedsBySexAsync(sexId));
    
    private async Task<IResult> GetById(Guid id, IEmployedControl control) =>
        await control.GetEmployedDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] Employed entity, IEmployedControl control)
    {
        await control.InsertEmployedAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/employeds/{entity.Id}", entity);
    }

    private async Task<IResult> Put([FromBody] Employed entity, IEmployedControl control)
    {
        await control.UpdateEmployedAsync(entity);
        await control.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(Guid id, IEmployedControl control)
    {
        await control.DeleteEmployedAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
    
    private async Task<IResult> SearchByQuery(string query, IEmployedControl control) =>
        await control.GetEmployedsByQueryAsync(query) is IEnumerable<Employed> entities
            ? Results.Ok(entities)
            : Results.NotFound(Array.Empty<Employed>());

}