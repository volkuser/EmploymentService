using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class VacancyApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/vacancies", Get) 
            .Produces<List<Vacancy>>(StatusCodes.Status200OK)
            .WithName("GetAllVacancies")
            .WithTags("Getters");
        app.MapGet("/vacancies/{professionId}", GetByProfession) 
            .Produces<List<Vacancy>>(StatusCodes.Status200OK)
            .WithName("GetAllVacanciesOfProfession")
            .WithTags("Getters");
        app.MapGet("/vacancies/{id}", GetById) 
            .Produces<Vacancy>(StatusCodes.Status200OK)
            .WithName("GetVacancy")
            .WithTags("Getters");
        app.MapPost("/vacancies", Post) 
            .Accepts<Vacancy>("application/json")
            .Produces<List<Vacancy>>(StatusCodes.Status201Created)
            .WithName("InsertVacancy")
            .WithTags("Inserts");
        app.MapPut("/vacancies", Put) 
            .Accepts<Vacancy>("application/json")
            .WithName("UpdateVacancy")
            .WithTags("Updaters");
        app.MapDelete("/vacancies/{id}", Delete) 
            .WithName("DeleteVacancy")
            .WithTags("Deleters");
    }
    
    private async Task<IResult> Get(IVacancyControl control) =>
        Results.Ok(await control.GetVacanciesAsync());
    private async Task<IResult> GetByProfession(Guid professionId, IVacancyControl control) =>
        Results.Ok(await control.GetVacanciesByProfessionAsync(professionId));
    
    private async Task<IResult> GetById(Guid id, IVacancyControl control) =>
        await control.GetVacancyDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] Vacancy entity, IVacancyControl control)
    {
        await control.InsertVacancyAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/vacancies/{entity.Id}", entity);
    }

    private async Task<IResult> Put([FromBody] Vacancy entity, IVacancyControl control)
    {
        await control.UpdateVacancyAsync(entity);
        await control.SaveAsync();
        return Results.NoContent();
    }

    private async Task<IResult> Delete(Guid id, IVacancyControl control)
    {
        await control.DeleteVacancyAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
}