using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Purchase.Core.ApplicationServices.Orders.Commands;

namespace OnlineShop.Purchase.Endpoints.RestAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly ILogger<PurchaseController> _logger;
    private readonly ISender _cqrsSender;

    public PurchaseController(ILogger<PurchaseController> logger, ISender sender)
    {
        _logger = logger;
        _cqrsSender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Purchase([FromBody] PurchaseCommand command, CancellationToken cancellationToken)
    {
        var result = await _cqrsSender.Send(command, cancellationToken);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(Purchase), new { id = result.Value });
    }
}
