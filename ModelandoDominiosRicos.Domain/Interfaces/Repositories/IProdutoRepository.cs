using System;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories.Common;

namespace ModelandoDominiosRicos.Domain.Interfaces.Repositories;

public interface IProdutoRepository : IBaseRepository<Produto, Guid>
{
}

