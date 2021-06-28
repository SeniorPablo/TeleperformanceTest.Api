using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleperformanceTest.Core.DTOs;
using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Enumerations;
using TeleperformanceTest.Core.Interfaces.Services;
using TeleperformanceTest.Infrastructure.Interfaces;
using TeleperformanceTest.Api.Responses;
using System.Threading.Tasks;

namespace TeleperformanceTest.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Security(SecurityDto entity)
        {
            var security = _mapper.Map<Security>(entity);
            security.Password = _passwordService.Hash(security.Password);
            await _securityService.RegisterUser(security);
            entity = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(entity);
            return Ok(response);
        }
    }
}
