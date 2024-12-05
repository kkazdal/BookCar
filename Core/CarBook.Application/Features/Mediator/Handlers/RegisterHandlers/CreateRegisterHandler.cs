using System;
using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.RegisterCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.RegisterHandlers;

public class CreateRegisterHandler : IRequestHandler<CreateRegisterCommand>
{
    private readonly IRepository<User> _repository;

    public CreateRegisterHandler(IRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);


        await _repository.CreateAsync(new User
        {
            UserName = request.UserName,
            Password = hashedPassword, // Hash'lenmiş şifreyi kaydediyoruz
            UserRoleId = (int)Roles.Member,
            Email = request.Email,
            Name = request.Name,
            Surname = request.Surname
        });
    }
}
