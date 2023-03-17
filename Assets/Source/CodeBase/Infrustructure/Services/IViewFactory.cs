using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IViewFactory : IService
    {
        EntityView CreateEntityView(GameTransform transform, EntityType entityType, IRemoteCommander comander);
    }
}