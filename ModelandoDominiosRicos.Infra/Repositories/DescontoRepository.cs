using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Infra.Repositories
{
    internal class DescontoRepository : BaseRepository<Desconto, Guid> IDescontoRepository
    {
        public DescontoRepository(DbContext context) : base(context)
        {
        }
    }
}
