using Assets.Source.CodeBase.Entities;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IEntityKeeper : IService, IRemoteCommander
    {
        void AddEntity(Entity entity);
        List<Entity> GetAllEntityByType(EntityType type);
        void CleanUp();
    }
}
