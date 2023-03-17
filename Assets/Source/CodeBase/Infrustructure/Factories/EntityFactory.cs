using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure.Services;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IViewFactory _viewFactory;
        private readonly IEntityKeeper _entityKeeper;
        private readonly Score _score;
        private readonly Vector2 _startpoint = Vector2.one * 100;

        public EntityFactory(IViewFactory viewFactory, IEntityKeeper entityKeeper, ISceneContext context)
        {
            _viewFactory = viewFactory;      
            _entityKeeper = entityKeeper;
            _score = new Score();
            context.AddContext(typeof(Score), _score);
        }

        public Entity Create(EntityType entityType)
        {
            GameTransform transform = new GameTransform(_startpoint, Quaternion.identity);
            EntityView view = _viewFactory.CreateEntityView(transform, entityType, _entityKeeper);
            Entity createdEntity = new Entity(transform, view);
            RegisterEntity(createdEntity);

            return createdEntity;
        }

        private void RegisterEntity(Entity entity)
        {
            _score.AddEntity(entity.EntityView);
            _entityKeeper.AddEntity(entity);
        }
    }
}