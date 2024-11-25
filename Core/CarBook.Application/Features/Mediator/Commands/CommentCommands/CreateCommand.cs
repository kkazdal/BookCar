using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands;

public class CreateCommand : IRequest
{
    public string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int BlogId { get; set; }
    public string Email { get; set; }
}
