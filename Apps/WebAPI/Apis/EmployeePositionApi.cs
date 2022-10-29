using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class EmployeePositionApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/employeePositions", Get) 
            .Produces<List<EmployeePosition>>(StatusCodes.Status200OK)
            .WithName("GetAllEmployeePositions")
            .WithTags("Getters");
        app.MapGet("/employeePositions/search/employee/id/{employeeId}", GetByEmployee) 
            .Produces<List<EmployeePosition>>(StatusCodes.Status200OK)
            .WithName("GetAllPositionsByEmployee")
            .WithTags("Getters");
        app.MapGet("/employeePositions/{id}", GetById) 
            .Produces<EmployeePosition>(StatusCodes.Status200OK)
            .WithName("GetEmployeePosition")
            .WithTags("Getters");
        app.MapPost("/employeePositions", Post) 
            .Accepts<EmployeePosition>("application/json")
            .Produces<List<EmployeePosition>>(StatusCodes.Status201Created)
            .WithName("InsertEmployeePosition")
            .WithTags("Inserts");
        app.MapDelete("/employeePositions/{id}", Delete) 
            .WithName("DeleteEmployeePosition")
            .WithTags("Deleters");
    }
    
    private async Task<IResult> Get(IEmployeePositionControl control) =>
        Results.Ok(await control.GetEmployeePositionsAsync());
    private async Task<IResult> GetByEmployee(Guid employeePosition, IEmployeePositionControl control) =>
        Results.Ok(await control.GetEmployeePositionsAsync(employeePosition));
    
    private async Task<IResult> GetById(Guid id, IEmployeePositionControl control) =>
        await control.GetEmployeePositionDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();

    private async Task<IResult> Post([FromBody] EmployeePosition entity, IEmployeePositionControl control)
    {
        await control.InsertEmployeePositionAsync(entity);
        await control.SaveAsync();
        return Results.Created($"/employeePositions/{entity.Id}", entity);
    }

    private async Task<IResult> Delete(Guid id, IEmployeePositionControl control)
    {
        await control.DeleteEmployeePositionAsync(id);
        await control.SaveAsync();
        return Results.NoContent();
    }
}