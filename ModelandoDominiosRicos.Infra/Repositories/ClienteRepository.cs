using System;
using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Infra.Data;
using ModelandoDominiosRicos.Infra.Repositories.Common;

namespace ModelandoDominiosRicos.Infra.Repositories;

public class ClienteRepository : BaseRepository<Cliente, Guid>, IClienteRepository
{
    public ClienteRepository(DataContext context) : base(context) 
    {
    }

    public Task<Cliente> ObtemClientePorEmail(string email)
    {
        var cliente = DbSet.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        return cliente;
    }

    public async Task<IEnumerable<Cliente>> ObtemClientesPorNome(string nome)
    {
        return DbSet.Where(x => x.Nome == nome).ToList();
    }
}

