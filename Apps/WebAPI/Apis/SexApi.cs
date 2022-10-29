using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class SexApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/sexes", Get) 
            .Produces<List<Sex>>(StatusCodes.Status200OK)
            .WithName("GetAllSexes")
            .WithTags("Getters");
        app.MapGet("/sexes/{id}", GetById) 
            .Produces<Sex>(StatusCodes.Status200OK)
            .WithName("GetSex")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(ISexControl control) =>
        Results.Ok(await control.GetSexesAsync());
    
    private async Task<IResult> GetById(char id, ISexControl control) =>
        await control.GetSexDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();
}