using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands;

public class RemoveAuthorCommand : IRequest
{
    public int AuthorId { get; set; }

    public RemoveAuthorCommand(int authorId)
    {
        AuthorId = authorId;
    }
}
