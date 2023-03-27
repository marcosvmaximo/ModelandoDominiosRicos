using MediatR;
using ModelandoDominiosRicos.CrossCutting.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Application.DescontoContext.Queries;

public class ObterDescontoValidosCommand : IRequest<BaseResult>
{
    public DateTime DataAtual { get; set; }
}
