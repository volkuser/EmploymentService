using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class ProfessionApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/professions", Get) 
            .Produces<List<Profession>>(StatusCodes.Status200OK)
            .WithName("GetAllProfessions")
            .WithTags("Getters");
        app.MapGet("/professions/{id}", GetById) 
            .Produces<Profession>(StatusCodes.Status200OK)
            .WithName("GetProfession")
            .WithTags("Getters");
        app.MapPost("/professions", Post) 
            .Accepts<Profession>("application/json")
            .Produces<List<Profession>>(StatusCodes.Status201Created)
            .WithName("InsertProfession")
            .WithTags("Inserts");
        app.MapPut("/professions", Put) 
            .Accepts<Profession>("application/json")
            .WithName("UpdateProfession")
            .WithTags("Updaters");
        app.MapDelete("/professions/{id}", Delete) 
            .WithName("DeleteProfession")
            .WithTags("Deleters");

        app.MapGet("/professions/search/name/{query}", SearchByName)
            .Produces<List<Profession>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchProfessionsByName")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(IProfessionControl control) =>
        Results.Ok(await control.GetProfessionsAsync());
    
    private async Task<IResult> GetById(Guid id, IProfessionControl control) =>
        await control.GetProfessionDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] Profession entity, IProfessionControl control)
    {
        await control.InsertProfessionAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/professions/{entity.Id}", entity);
    }

    private async Task<IResult> Put([FromBody] Profession entity, IProfessionControl control)
    {
        await control.UpdateProfessionAsync(entity);
        await control.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(Guid id, IProfessionControl control)
    {
        await control.DeleteProfessionAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
    
    private async Task<IResult> SearchByName(string query, IProfessionControl control) =>
        await control.GetProfessionsAsync(query) is IEnumerable<Profession> entities
            ? Results.Ok(entities)
            : Results.NotFound(Array.Empty<Profession>());
}