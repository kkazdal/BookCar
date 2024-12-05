using System;

namespace CarBook.Application.Tools;

public class JwtSettings
{
    public string IssuerSigningKey { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
}
