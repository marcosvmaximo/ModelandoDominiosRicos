using System;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories.Common;

namespace ModelandoDominiosRicos.Domain.Interfaces.Repositories;

public interface IClienteRepository : IBaseRepository<Cliente, Guid>
{
    Task<IEnumerable<Cliente>> ObtemClientesPorNome(string nome);
    Task<Cliente> ObtemClientePorEmail(string email);
}

