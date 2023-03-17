using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.CodeBase.Systems
{
    public class AsteroidMovingSystem : IUpdatable
    {
        private readonly IEntityKeeper _entityKeeper;
        private readonly float _asteroidSpeed;
        private readonly float _partOfAsteroidSpeed;


        public AsteroidMovingSystem(IEntityKeeper entityKeeper, float asteroidSpeed, float partOfAsteroidSpeed)
        {
            _entityKeeper = entityKeeper;
            _asteroidSpeed = asteroidSpeed;
            _partOfAsteroidSpeed = partOfAsteroidSpeed;
        }

        public void Update(float tick)
        {
            List<Entity> updatingAsteroids = _entityKeeper.GetAllEntityByType(EntityType.Asteroid);

            foreach (Entity entity in updatingAsteroids)
            {
                entity.Transform.Position.Value += entity.Transform.Forward * _asteroidSpeed * tick;
            }

            List<Entity> updatingPartOfAsteroids = _entityKeeper.GetAllEntityByType(EntityType.PartOfAsteroid);

            foreach (Entity entity in updatingPartOfAsteroids)
            {
                entity.Transform.Position.Value += entity.Transform.Forward * _partOfAsteroidSpeed * tick;
            }
        }
    }
}
