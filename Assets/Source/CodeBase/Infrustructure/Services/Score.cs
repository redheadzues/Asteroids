using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public class Score : IResetable
    {
        private readonly List<EntityType> _scorableEntity = new List<EntityType>() { EntityType.Asteroid, EntityType.Ufo, EntityType.PartOfAsteroid };
        private int _score = 0;

        public void AddEntity(EntityView entity)
        {
            if (_scorableEntity.Contains(entity.EntityType))
                entity.DamageGetted += OnEntityDamageGetted;
        }

        public int GetScore() =>
            _score;

        public void Reset() => 
            _score = 0;

        private void OnEntityDamageGetted(EntityView entity)
        {
            entity.DamageGetted -= OnEntityDamageGetted;
            _score++;
        }
    }
}
