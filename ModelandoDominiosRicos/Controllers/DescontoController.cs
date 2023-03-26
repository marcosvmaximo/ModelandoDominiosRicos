using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.Application.DescontoContext.Commands;
using ModelandoDominiosRicos.Application.DescontoContext.Queries;

namespace ModelandoDominiosRicos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DescontoController : ControllerBase
{
    private readonly IMediator _mediator;

    public DescontoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarDesconto(CriarDescontoCommand request)
    {
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

    [HttpGet]
    public async Task<IActionResult> ObterDescontoValidos(ObterDescontoValidosCommand request)
    {
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
}

