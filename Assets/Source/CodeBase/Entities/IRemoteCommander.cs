using System;

namespace Assets.Source.CodeBase.Entities
{
    public interface IRemoteCommander
    {
        event Action Destroy;
    }
}
