using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class PositionApi : IApi
{
        public void Register(WebApplication app)
    {
        app.MapGet("/positions", Get) 
            .Produces<List<Position>>(StatusCodes.Status200OK)
            .WithName("GetAllPositions")
            .WithTags("Getters");
        app.MapGet("/positions/{id}", GetById) 
            .Produces<Position>(StatusCodes.Status200OK)
            .WithName("GetPosition")
            .WithTags("Getters");
        app.MapPut("/positions", Put) 
            .Accepts<Position>("application/json")
            .WithName("UpdatePosition")
            .WithTags("Updaters");
    }
    
    private async Task<IResult> Get(IPositionControl control) =>
        Results.Ok(await control.GetPositionsAsync());
    
    private async Task<IResult> GetById(Guid id, IPositionControl control) =>
        await control.GetPositionDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Put([FromBody] Position entity, IPositionControl control)
    {
        await control.UpdatePositionAsync(entity);
        await control.SaveAsync();
        return Results.NoContent();
    }
}