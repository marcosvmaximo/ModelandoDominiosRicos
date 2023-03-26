using System;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Infra.Data;
using ModelandoDominiosRicos.Infra.Repositories.Common;

namespace ModelandoDominiosRicos.Infra.Repositories;

public class ProdutoRepository : BaseRepository<Produto, Guid>, IProdutoRepository
{
    public ProdutoRepository(DataContext context) : base(context)
    {
    }
}

