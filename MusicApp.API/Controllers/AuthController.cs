using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicApp.API.Data;
using MusicApp.API.DTOs;
using MusicApp.API.Models;

namespace MusicApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;
        private readonly IMapper mapper;
        public AuthController(IAuthRepository repository, IConfiguration configuration, IMapper _mapper)
        {
            mapper = _mapper;
            config = configuration;
            repo = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDTO dto)
        {
            if (!string.IsNullOrEmpty(dto.UserName))
                dto.UserName = dto.UserName.ToLower();

            if (await repo.UserExists(dto.UserName))
                ModelState.AddModelError("UserName", "Usernameis already taken");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToCreate = mapper.Map<User>(dto);

            var createdUser = await repo.Register(userToCreate, dto.Password);

            var userToReturn = mapper.Map<UserDetailDTO>(createdUser);

            return CreatedAtAction("Register", userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDTO dto)
        {
            var user = await repo.Login(dto.UserName, dto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddDays(40),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });
        }
    }
}