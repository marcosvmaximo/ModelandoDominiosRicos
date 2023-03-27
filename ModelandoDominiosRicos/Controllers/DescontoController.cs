using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.Application.DescontoContext.Commands;
using ModelandoDominiosRicos.Application.DescontoContext.Queries;
using ModelandoDominiosRicos.CrossCutting.Results;

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


    /// <summary>
    /// Cria um desconto novo
    /// </summary>
    /// <returns>Retorna um desconto criado</returns>
    /// <response code="200">Retorna um desconto</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
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


    /// <summary>
    /// Obtem todos descontos com a validade ainda não expiradas
    /// </summary>
    /// <returns>Retorna todos descontos valido</returns>
    /// <response code="200">Retorna uma lista de descontos</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    [HttpGet]
    public async Task<IActionResult> ObterDescontoValidos(ObterDescontoValidosQuery request)
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

