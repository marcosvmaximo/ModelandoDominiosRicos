using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task CriarDesconto()
    {

    }
    [HttpGet]
    public async Task VerificarDesconto()
    {

    }
}

