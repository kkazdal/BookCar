using System;
using CarBook.Application.Features.Mediator.Queries.UserQueries;
using CarBook.Application.Features.Mediator.Results.UserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Tools;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.UserQueryHandlers;

public class GetCheckUserQueryHandler : IRequestHandler<GetCheckUserQuery, GetCheckUserQueryResult>
{
    private readonly IRepository<UserRole> _userRoleRepository;
    private readonly IRepository<User> _userRepository;

    public GetCheckUserQueryHandler(IRepository<User> userRepository, IRepository<UserRole> userRoleRepository)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<GetCheckUserQueryResult> Handle(GetCheckUserQuery request, CancellationToken cancellationToken)
    {
        var values = new GetCheckUserQueryResult();

        var user = await _userRepository.GetByFilterAsync(x => x.UserName == request.UserName);

        if (user == null)
        {
            values.IsExist = false;
            return values;
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (!isPasswordValid)
        {
            values.IsExist = false;
            return values;
        }

        values.IsExist = true;
        values.UserName = user.UserName;
        values.Role = (await _userRoleRepository.GetByFilterAsync(x => x.Id == user.UserRoleId)).UserRoleName;
        values.Id = user.Id;

        return values;
    }
}
