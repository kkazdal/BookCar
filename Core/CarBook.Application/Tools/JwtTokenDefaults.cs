using System;

namespace CarBook.Application.Tools;

public class JwtTokenDefaults
{
    public const string ValidAudience = "http://localhost";
    public const string ValidIssuer = "http://localhost";
    public const string IssuerSigningKey = "MIHcAgEBBEIA6IDIosW41Gzuk73T5LpRPNA3KBtwX40o9wP77Bq1wv8oqpP0faIw";
    public const int Expire = 3;//minute

}
