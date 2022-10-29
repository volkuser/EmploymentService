using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class JobApplicationApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/jobApplications", Get) 
            .Produces<List<JobApplication>>(StatusCodes.Status200OK)
            .WithName("GetAllJobApplications")
            .WithTags("Getters");
        app.MapGet("/jobApplications/{jobApplicationId}", GetByEmployed) 
            .Produces<List<JobApplication>>(StatusCodes.Status200OK)
            .WithName("GetAllJobApplicationsForEmployed")
            .WithTags("Getters");
        app.MapGet("/jobApplications/{id}", GetById) 
            .Produces<JobApplication>(StatusCodes.Status200OK)
            .WithName("GetJobApplication")
            .WithTags("Getters");
        app.MapPost("/jobApplications", Post) 
            .Accepts<JobApplication>("application/json")
            .Produces<List<JobApplication>>(StatusCodes.Status201Created)
            .WithName("InsertJobApplication")
            .WithTags("Inserts");
        app.MapDelete("/jobApplications/{id}", Delete) 
            .WithName("DeleteJobApplication")
            .WithTags("Deleters");
    }
    
    private async Task<IResult> Get(IJobApplicationControl control) =>
        Results.Ok(await control.GetJobApplicationsAsync());
    private async Task<IResult> GetByEmployed(Guid employedId, IJobApplicationControl control) =>
        Results.Ok(await control.GetJobApplicationsAsync(employedId));
    
    private async Task<IResult> GetById(Guid id, IJobApplicationControl control) =>
        await control.GetJobApplicationsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] JobApplication entity, IJobApplicationControl control)
    {
        await control.InsertJobApplicationAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/jobApplications/{entity.Id}", entity);
    }

    private async Task<IResult> Delete(Guid id, IJobApplicationControl control)
    {
        await control.DeleteJobApplicationAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
}