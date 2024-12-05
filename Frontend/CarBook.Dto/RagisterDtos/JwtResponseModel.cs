using System;

namespace CarBook.Dto.RagisterDtos;

public class JwtResponseModel
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}
