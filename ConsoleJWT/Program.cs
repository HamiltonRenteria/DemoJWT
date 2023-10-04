using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// Clave secreta, sirve para firmar el token.
string secretKey = "EstaEsMiClaveSecreta2023";

// Se crean los Claims para el payload (Estos son personalizables)
var claims = new[]
{
    new Claim(JwtRegisteredClaimNames.Email, "demojwt@demo.com"),
    new Claim(JwtRegisteredClaimNames.Name, "Demo JWT"),
    new Claim(JwtRegisteredClaimNames.Sub, "JWTDemoUser"),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Id único del Token.
};

// Se crea un objeto de configuración para el token.
var ConfigToken = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));
var credentials = new SigningCredentials(ConfigToken, SecurityAlgorithms.HmacSha256);

// Se configura el Token.
var token = new JwtSecurityToken(
        claims: claims, 
        expires: DateTime.UtcNow.AddHours(1), // Tiempo de duración o expiración del token.
        signingCredentials: credentials
    );

// Se serializa el token a una cadena.
var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

Console.WriteLine("El token generado es: ");
Console.WriteLine(tokenString);
