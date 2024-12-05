using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.RegisterCommands;

public class CreateRegisterCommand : IRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public int UserRoleId { get; set; }
}
