using Entities.Models;
using WebAPI.Controls.Contracts;

namespace WebAPI.Apis;

public class EmployeeApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/employees", Get) 
            .Produces<List<Employee>>(StatusCodes.Status200OK)
            .WithName("GetAllEmployees")
            .WithTags("Getters");
        app.MapGet("/employees/{id}", GetById) 
            .Produces<Employee>(StatusCodes.Status200OK)
            .WithName("GetEmployee")
            .WithTags("Getters");
        
        app.MapGet("/employees/search/{query}", SearchByName)
            .Produces<List<Employee>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchEmployeesByQuery")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(IEmployeeControl control) =>
        Results.Ok(await control.GetEmployeesAsync());
    
    private async Task<IResult> GetById(Guid id, IEmployeeControl control) =>
        await control.GetEmployeeDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();
    
    private async Task<IResult> SearchByName(string query, IEmployeeControl control) =>
        await control.GetEmployeesAsync(query) is IEnumerable<Employee> entities
            ? Results.Ok(entities)
            : Results.NotFound(Array.Empty<Profession>());
}