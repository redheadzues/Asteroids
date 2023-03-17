using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly IStaticDataService _staticDataService;

        public ViewFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public EntityView CreateEntityView(GameTransform transform, EntityType entityType, IRemoteCommander comander)
        {
            EntityStaticData entityData = _staticDataService.GetEntityData(entityType);

            EntityView entity = Object.Instantiate(entityData.Prefab);

            entity.Construct(entityType, entityData.DeathChecker, comander);
            entity.GetComponent<TransformSetter>().Construct(transform.Position, transform.Rotation);

            return entity;
        }

    }
}