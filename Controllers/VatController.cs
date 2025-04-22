using GlobalBlue.Api.Models;
using GlobalBlue.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GlobalBlue.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VatController : ControllerBase
    {
        private readonly IVatCalculator _calculator;
        private readonly ILogger<VatController> _logger;
        public VatController(IVatCalculator calculator, ILogger<VatController> logger)
        {
            _calculator = calculator;
            _logger = logger;
        }

        [HttpPost("calculate")]
        public ActionResult<VatCalculationResponse> Calculate([FromBody] VatCalculationRequest req)
        {
            _logger.LogInformation("Calc request: {@Request}", req);
            try
            {
                var result = _calculator.Calculate(req);
                _logger.LogInformation("Calc result: {@Result}", result);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Bad request data");
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
