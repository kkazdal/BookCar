using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarRespositories;
using CarBook.CarBookDomain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebApi.Hubs;

public class CarHub : Hub
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IRepository<Car> _carRepository;

    public CarHub(IHttpClientFactory httpClientFactory, IRepository<Car> carRepository)
    {
        _httpClientFactory = httpClientFactory;
        _carRepository = carRepository;
    }

    public async Task SendCarCount()
    {
        var responseMessage = (await _carRepository.GetAllAsync()).Count;
        await Clients.All.SendAsync("ReceiveCarCount", responseMessage);
    }
}
