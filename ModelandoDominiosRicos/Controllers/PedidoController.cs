using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelandoDominiosRicos.Application.PedidoContext.Commands;

namespace ModelandoDominiosRicos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IMediator _mediator;

    public PedidoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpGet]
    //public async Task<IActionResult> Index()
    //{
    //}

    [HttpPost]
    public async Task<IActionResult> CriarItemPedidoParaCliente([FromBody]AdicionarItemPedidoCommand request)
    {
        // adiciono um pedido com quantidade e produto
        // adiciono a onde?
        // Cliente? Pedido?
        var response = await _mediator.Send(request);

        if (response.Sucess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }

    //[HttpPost]
    //public async Task<IActionResult> CriarPedido()
    //{

    //}
}
