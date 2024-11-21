using System;
using System.Collections;

namespace CarBook.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string Email { get; set; }
    public List<RentACarProcess> RentACarProcesses { get; set; }
}
