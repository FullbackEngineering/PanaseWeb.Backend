using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Panase.Application.Features.Users.Login.Dtos;
using Panase.Application.Features.Users.Login.Queries;
using Panase.Application.Features.Users.Register.Dtos;

namespace Panase.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Yeni kullanıcı kaydı yapar.
        /// </summary>
        /// <param name="request">Kayıt için gerekli bilgiler</param>
        /// <returns>Kayıt bilgileri ve token</returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Register request validation failed.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration.");
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Kullanıcı giriş yapar.
        /// </summary>
        /// <param name="request">Giriş için gerekli email ve şifre</param>
        /// <returns>JWT Token ve kullanıcı bilgileri</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] LoginQuery request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Login request validation failed.");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Invalid login attempt.");
                return Unauthorized(new { error = "Geçersiz kullanıcı adı veya şifre." });
            }
        }
    }
}
