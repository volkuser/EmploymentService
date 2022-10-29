using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class EducationForProfessionApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/educationsForProfessions", Get) 
            .Produces<List<EducationForProfession>>(StatusCodes.Status200OK)
            .WithName("GetAllPEducationsForProfessions")
            .WithTags("Getters");
        app.MapGet("/educationsForProfession", GetForSingleProfession) 
            .Produces<List<EducationForProfession>>(StatusCodes.Status200OK)
            .WithName("GetAllPEducationsForProfession")
            .WithTags("Getters");
        app.MapGet("/educationsForProfessions/{id}", GetById) 
            .Produces<EducationForProfession>(StatusCodes.Status200OK)
            .WithName("GetEducationForProfession")
            .WithTags("Getters");
        app.MapPost("/educationsForProfessions", Post) 
            .Accepts<EducationForProfession>("application/json")
            .Produces<List<EducationForProfession>>(StatusCodes.Status201Created)
            .WithName("InsertEducationForProfession")
            .WithTags("Inserts");
        app.MapDelete("/educationsForProfessions/{id}", Delete) 
            .WithName("DeleteEducationForProfession")
            .WithTags("Deleters");
    }
    
    private async Task<IResult> Get(IEducationForProfessionControl control) =>
        Results.Ok(await control.GetEducationsForProfessionsAsync());
    
    private async Task<IResult> GetForSingleProfession(Guid professionId, IEducationForProfessionControl control) =>
        Results.Ok(await control.GetEducationsForProfessionAsync(professionId));
    
    private async Task<IResult> GetById(Guid id, IEducationForProfessionControl control) =>
        await control.GetEducationForProfessionDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] EducationForProfession entity, IEducationForProfessionControl control)
    {
        await control.InsertEducationForProfessionAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/educationsForProfessions/{entity.Id}", entity);
    }

    private async Task<IResult> Delete(Guid id, IEducationForProfessionControl control)
    {
        await control.DeleteEducationForProfessionAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
}