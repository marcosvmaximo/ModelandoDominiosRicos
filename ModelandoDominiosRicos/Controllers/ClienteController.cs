using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.Application.Commands;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cadastra um Cliente
    /// </summary>
    /// <returns>Cadastra um novo Cliente</returns>
    /// <response code="200">Retorna um novo Cliente</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    public async Task<IActionResult> CadastrarCliente(CadastrarClienteCommand request)
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
    /// Altera o nome de um Cliente existente
    /// </summary>
    /// <returns>Cliente com novo nome</returns>
    /// <response code="200">Retorna o Cliente com nome atualizado</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [HttpPatch]
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    public async Task<IActionResult> AlterarNomeCliente(AlterarNomeClienteCommand request)
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
    /// Obtem um Cliente através do email informado
    /// </summary>
    /// <returns>Um Cliente através do Email</returns>
    /// <response code="200">Retorna um Cliente</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [HttpGet("{email}")]
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    public async Task<ActionResult<Cliente>> ObterClientePorEmail([FromRoute] string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest($"{email} informado é invalido, por favor informe um correto");
        }

        var requestEmail = new ObterClientePorEmailQuery() { Email = email };

        var response = await _mediator.Send(requestEmail);

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
    /// Obtem todos os Clientes
    /// </summary>
    /// <returns>Uma lista de todos clientes</returns>
    /// <response code="200">Retorna a lista de clientes</response>
    /// <response code="400">Se ocorrer um erro de validação</response>
    /// <response code="500">Se ocorrer um erro interno</response>
    [HttpGet]
    [ProducesResponseType(typeof(BaseResult), 200)]
    [ProducesResponseType(typeof(BaseResult), 400)]
    [ProducesResponseType(typeof(BaseResult), 404)]
    public async Task<ActionResult<IAsyncEnumerable<Cliente>>> ObterTodosClientes()
    {
        var requestClientes = new ObterTodosClientesQuery();

        var response = await _mediator.Send(requestClientes);

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

