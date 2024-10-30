using System;
using CarBook.Application.Features.Mediator.Commands.FooterAddress;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class RemoveFooterAddressHandle : IRequestHandler<RemoveFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _repository;

    public RemoveFooterAddressHandle(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var footerAddress = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(footerAddress);
    }
}
