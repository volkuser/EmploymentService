using MediatR;

namespace Controls.ForModels.Professions.Commands.Inserting;

public class InsertProfessionCommand : IRequest<Guid>
{
    public Guid User;
}