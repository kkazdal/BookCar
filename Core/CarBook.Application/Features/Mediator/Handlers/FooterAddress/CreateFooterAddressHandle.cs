using System;
using CarBook.Application.Features.Mediator.Commands.FooterAddress;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class CreateFooterAddressHandle : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _repository;

    public CreateFooterAddressHandle(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(
            new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                EMail = request.EMail,
                Phone = request.Phone
            }
        );
    }
}
