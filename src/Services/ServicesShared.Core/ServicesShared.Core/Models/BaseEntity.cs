using System;

namespace Services.ServicesShared.Core.Models
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
