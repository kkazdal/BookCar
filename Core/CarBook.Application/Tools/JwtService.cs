using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarBook.Application.Dtos;
using CarBook.Application.Features.Mediator.Results.UserResults;
using CarBook.Application.Tools;
using Microsoft.IdentityModel.Tokens;

public class JwtService
{
    private readonly string _issuerSigningKey;
    private readonly string _validIssuer;
    private readonly string _validAudience;

    public JwtService(string issuerSigningKey, string validIssuer, string validAudience)
    {
        _issuerSigningKey = issuerSigningKey;
        _validIssuer = validIssuer;
        _validAudience = validAudience;
    }

    public TokenResponseDto GenerateToken(GetCheckUserQueryResult result)
    {
        var claims = new List<Claim>();

        if (!string.IsNullOrWhiteSpace(result.Role))
            claims.Add(new Claim(ClaimTypes.Role, result.Role));

        claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

        if (!string.IsNullOrWhiteSpace(result.UserName))
            claims.Add(new Claim("UserName", result.UserName));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_issuerSigningKey));

        var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//Token'ın hangi algoritma ve anahtarla imzalanacağını belirtiyoruz. Burada HMAC-SHA256 algoritması kullanılıyor.

        var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire); //Her token'ın bir sona erme tarihi olmalıdır. Bu, güvenliği artırır ve token'ların süresiz kullanılmasını engeller.

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _validIssuer,
            audience: _validAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expireDate,
            signingCredentials: signinCredentials
          );


        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        return new TokenResponseDto(tokenHandler.WriteToken(jwtSecurityToken), expireDate);
    }
}

