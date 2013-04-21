using System;

namespace DevLib.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}