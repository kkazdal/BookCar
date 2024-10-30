using System;
using CarBook.Application.Features.Mediator.Commands.FooterAddress;
using CarBook.Application.Interfaces;
using CarBook.CarBookDomain.Entities;
using MediatR;


public class UpdateFooterAddressHandle : IRequestHandler<UpdateFooterAddressCommand>
{
    private readonly IRepository<FooterAddress> _repository;
    public UpdateFooterAddressHandle(IRepository<FooterAddress> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        response.Address = request.Address;
        response.Description = request.Description;
        response.Phone = request.Phone;
        response.EMail = request.EMail;

        await _repository.UpdateAsync(response);
    }
}
