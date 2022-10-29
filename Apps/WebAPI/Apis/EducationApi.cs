using Entities.Models;
using WebAPI.Controls.Contracts;
  
namespace WebAPI.Apis;

public class EducationApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/educations", Get)
            .Produces<List<Education>>(StatusCodes.Status200OK)
            .WithName("GetAllEducations")
            .WithTags("Getters");
        app.MapGet("/educations/{id}", GetById)
            .Produces<Education>(StatusCodes.Status200OK)
            .WithName("GetEducation")
            .WithTags("Getters");

        app.MapGet("/educations/search/name/{query}", SearchByName)
            .Produces<List<Education>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchEducationsByName")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(IEducationControl control) =>
        Results.Ok(await control.GetEducationsAsync());
    
    private async Task<IResult> GetById(int id, IEducationControl control) =>
        await control.GetEducationDetailsAsync(id) is { } entity
            ? Results.Ok(entity)
            : Results.NotFound();
    
    private async Task<IResult> SearchByName(string query, IEducationControl control) =>
        await control.GetEducationsAsync(query) is IEnumerable<Education> entities
            ? Results.Ok(entities)
            : Results.NotFound(Array.Empty<Education>());
}