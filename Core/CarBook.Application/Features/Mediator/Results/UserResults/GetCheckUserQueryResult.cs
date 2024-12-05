using System;

namespace CarBook.Application.Features.Mediator.Results.UserResults;

public class GetCheckUserQueryResult
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public bool IsExist { get; set; }
}
