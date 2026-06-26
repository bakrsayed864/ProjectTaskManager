using Application.Contracts.Services;
using Application.Core.Models;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Services
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ApplicationDbContext _context;
		private readonly SecurityKey signingKey;
		private readonly JWTOptions _jwtOptions;

		public TokenService(IConfiguration configuration,
		IOptions<JWTOptions> jwtOptions,
		RoleManager<IdentityRole<Guid>> roleManager,
		ApplicationDbContext context)
		{
			_configuration = configuration;
            _roleManager = roleManager;
            _context = context;
			signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]!));
			_jwtOptions = jwtOptions.Value;
		}

		public async Task<JwtSecurityToken> CreateTokenAsync(ApplicationUser user)
		{
			//register claims
			var registeredClaims = new List<Claim>
			{
				new(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new(ClaimTypes.Name, user.UserName!),
				new(ClaimTypes.Email, user.Email!),
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

            // Get user roles with their tenant information
            var userRoles = await _roleManager.Roles.Where(u => u.Id == user.Id).ToListAsync();
				

			foreach (var userRole in userRoles)
			{
				if (userRole == null) continue;

				//
				registeredClaims.Add(new Claim(ClaimTypes.Role, userRole.Name!));
			}

			SigningCredentials signCred = new(signingKey, SecurityAlgorithms.HmacSha256);
			JwtSecurityToken token = new(
				issuer: _jwtOptions.Issuer,
				audience: _jwtOptions.Audience,
				claims: registeredClaims,
				expires: DateTime.Now.AddMinutes(_jwtOptions.ExpiryMinutes),
				signingCredentials: signCred
				);

			return token;
		}
	}
}
