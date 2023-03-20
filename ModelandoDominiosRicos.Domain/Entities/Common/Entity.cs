using Flunt.Notifications;
using ModelandoDominiosRicos.CrossCutting.Interfaces;

namespace ModelandoDominiosRicos.Domain.Entities.Common;

public abstract class Entity : Notifiable<Notification>, IContract
{
    public Entity()
    {
        Id = Guid.NewGuid();
        TimeStamp = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public DateTime TimeStamp { get; private set; }

    public abstract bool Validate();
}