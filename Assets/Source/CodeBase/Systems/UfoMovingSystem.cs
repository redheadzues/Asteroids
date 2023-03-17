using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.CodeBase.Systems
{
    public class UfoMovingSystem : IUpdatable
    {
        private readonly IEntityKeeper _entityKeeper;
        private readonly IReadOnlyObservable<Vector2> _targetPosition;
        private readonly float _speed;

        public UfoMovingSystem(IEntityKeeper entityKeeper, IReadOnlyObservable<Vector2> targetPosition, float speed)
        {
            _entityKeeper = entityKeeper;
            _targetPosition = targetPosition;
            _speed = speed;
        }

        public void Update(float tick)
        {
            List<Entity> updatingEntities = _entityKeeper.GetAllEntityByType(EntityType.Ufo);

            foreach(var entity in updatingEntities)
            {
                entity.Transform.Position.Value = Vector2.MoveTowards(entity.Transform.Position.Value, _targetPosition.Value, _speed * tick);
            }
        }
    }
}
