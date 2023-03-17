using Assets.Source.CodeBase.Entities;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IEntityFactory : IService
    {
        Entity Create(EntityType entityType);
    }
}