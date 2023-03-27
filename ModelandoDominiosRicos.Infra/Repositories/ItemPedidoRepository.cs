using System;
using Microsoft.EntityFrameworkCore;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using ModelandoDominiosRicos.Infra.Data;
using ModelandoDominiosRicos.Infra.Repositories.Common;

namespace ModelandoDominiosRicos.Infra.Repositories;

public class ItemPedidoRepository : BaseRepository<ItemPedido, Guid>, IItemPedidoRepository
{
    public ItemPedidoRepository(DataContext context) : base(context)
    {
    }
}

