using System;
using Flunt.Notifications;

namespace Eventos.Shared.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}