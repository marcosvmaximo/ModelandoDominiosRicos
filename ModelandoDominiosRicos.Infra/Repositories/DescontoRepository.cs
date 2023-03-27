using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Infra.Data;
using ModelandoDominiosRicos.Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Infra.Repositories;

public class DescontoRepository : BaseRepository<Desconto, Guid>, IDescontoRepository
{
    public DescontoRepository(DataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Desconto>> GetDescontosDataValida()
    {
        return DbSet.Where(x => x.DataExpiracao > DateTime.Now).ToList();
    }
}
