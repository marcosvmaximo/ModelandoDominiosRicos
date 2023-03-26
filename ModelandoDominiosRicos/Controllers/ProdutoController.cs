using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.Application.ProdutoContext.Commands;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Insere um novo produto
    /// </summary>
    /// <returns>Retorna um produto criado</returns>
    /// <response code="200">Retorna um produto criado</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    public async Task<IActionResult> InserirProduto(InserirProdutoCommand request)
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
    /// Insere um novo produto
    /// </summary>
    /// <returns>Retorna um produto criado</returns>
    /// <response code="200">Retorna um produto criado</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    [HttpPatch("{id}")]
    public async Task<IActionResult> AlterarStatusProduto([FromRoute]Guid id, [FromQuery] bool status)
    {
        AlterarStatusCommand request = new AlterarStatusCommand()
        {
            Id = id,
            NovoStatus = status
        };
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

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterProdutoPorId([FromRoute] Guid id)
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

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterProdutoPorId([FromRoute] Guid id)
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

