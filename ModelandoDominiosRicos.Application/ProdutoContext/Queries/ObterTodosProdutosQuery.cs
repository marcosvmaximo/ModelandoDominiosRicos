using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;
using MediatR;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Queries;

public class ObterTodosProdutosQuery : IRequest<BaseResult>, ICommand
{
    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}
