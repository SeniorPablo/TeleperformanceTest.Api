using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Interfaces.Services;

namespace TeleperformanceTest.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationTypesController : ControllerBase
    {
        private readonly ITypeIdentificationService _typeIdentificationService;
        public IdentificationTypesController(ITypeIdentificationService typeIdentificationService)
        {
            _typeIdentificationService = typeIdentificationService;
        }

        /// <summary>
        /// Retrieve all types of identifications
        /// </summary>
        /// <returns>Identification types list</returns>
        [HttpGet(Name = nameof(GetIdentificationTypes))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<IdentificationType>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(List<IdentificationType>))]
        public async Task<IActionResult> GetIdentificationTypes()
        {
            var ids = await _typeIdentificationService.GetIdentificationTypes();

            return Ok(ids);
        }
    }
}
