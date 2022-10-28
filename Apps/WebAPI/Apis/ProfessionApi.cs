using Entities.Models;
using WebAPI.Controls;

namespace WebAPI.Apis;

public class ProfessionApi : IApi
{
    public void Register(WebApplication app)
    {
        app.MapGet("/hotels", Get) 
            .Produces<List<Profession>>(StatusCodes.Status200OK)
            .WithName("GetAllProfessions")
            .WithTags("Getters");
    }
    
    private async Task<IResult> Get(IProfessionControl control) =>
        Results.Ok(await control.GetProfessionsAsync());
}