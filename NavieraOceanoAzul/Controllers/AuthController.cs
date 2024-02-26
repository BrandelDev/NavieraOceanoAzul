using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NavieraOceanoAzul.DTO;
using System.Text;
using NavieraOceanoAzul.Models;
using AutoMapper;
using BCrypt.Net;

namespace NavieraOceanoAzul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string secretKey;
        private readonly noaContext _context;
        private readonly IMapper _mapper;

        public AuthController(
            IConfiguration config,
            noaContext context,
            IMapper mapper
            ) 
        {
            _mapper = mapper;
            _context = context;
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        [HttpPost]
        [Route("Validate")]

        public IActionResult Validate([FromBody] UsuarioDTO usuarioDto)
        {

            var userSingIn = _context.Clientes.FirstOrDefault(x => x.Email == usuarioDto.Email);
            if(userSingIn != null) {
            if (usuarioDto.Email == userSingIn.Email && BCrypt.Net.BCrypt.Verify(usuarioDto.password, userSingIn.Contrasena))
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuarioDto.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" }); 

            }
            }return BadRequest("Usuario no encontrado");
        }

        [HttpPost]
        [Route("CreateUser")]

        public async Task<IActionResult> CreateUser([FromBody] ClienteDTO usuarioDto)
        {

            if (_context.Clientes.Any(x => x.Email == usuarioDto.Email))
                throw new Exception("El correo " + usuarioDto.Email + " Ya se encuentra registrado");
            var newClient = _mapper.Map<Cliente>(usuarioDto);
            
            newClient.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Contrasena);

            if (ModelState.IsValid)
            {
                _context.Add(newClient);
                await _context.SaveChangesAsync();
                return Ok(newClient);
            }

            return BadRequest(ModelState);

        }
    }
  

}
