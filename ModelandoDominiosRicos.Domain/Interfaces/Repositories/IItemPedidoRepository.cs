using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Domain.Interfaces.Repositories;

public interface IItemPedidoRepository : IBaseRepository<ItemPedido, Guid>
{
}
