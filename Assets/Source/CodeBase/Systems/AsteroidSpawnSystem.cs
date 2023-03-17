using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure.Services;
using UnityEngine;

namespace Assets.Source.CodeBase.Systems
{
    public class AsteroidSpawnSystem : IUpdatable
    {
        private readonly IEntityFactory _entityFactory;
        private readonly float _spawnTime;
        private readonly RandomPositionGetter _randomPosition;

        private float _timeUntilSpawn;

        public AsteroidSpawnSystem(IEntityFactory entityFactory, float spawnTime)
        {
            _entityFactory = entityFactory;
            _spawnTime = spawnTime;
            _timeUntilSpawn = spawnTime;
            _randomPosition = new RandomPositionGetter();
        }

        public void Update(float tick)
        {
            _timeUntilSpawn -= tick;

            if (_timeUntilSpawn <= 0)
            {
                CreateAsteroid();

                _timeUntilSpawn = _spawnTime;
            }
        }

        private void CreateAsteroid()
        {
            Entity entity = _entityFactory.Create(EntityType.Asteroid);
            entity.Transform.Position.Value = _randomPosition.GetRandomPositionOutsideScreen();

            SetRotation(entity);

            entity.EntityView.DamageGetted += OnAsteroidDamageGetted;
            entity.EntityView.Died += OnDied;
        }


        private void SetRotation(Entity entity)
        {
            Vector2 lookPosition = _randomPosition.GetRandomPositionInsideScreen();
            Vector2 direction = lookPosition - entity.Transform.Position.Value;

            entity.Transform.Rotation.Value = Quaternion.LookRotation(Vector3.forward, direction);
        }

        private void OnAsteroidDamageGetted(EntityView view)
        {
            view.DamageGetted -= OnAsteroidDamageGetted;
            Vector2 spawnPosition = new Vector2(view.transform.position.x, view.transform.position.y);

            for(int i = 0; i < 4; i++)
                CreatePartOfAsteroid(spawnPosition);
        }

        private void CreatePartOfAsteroid(Vector2 spawnPosition)
        {
            Entity entity = _entityFactory.Create(EntityType.PartOfAsteroid);
            entity.EntityView.transform.localScale = Vector3.one * 0.5f;
            entity.Transform.Position.Value = spawnPosition;

            int randomRotation = Random.Range(0, 360);

            entity.Transform.Rotation.Value = Quaternion.Euler(0, 0, randomRotation);
        }

        private void OnDied(EntityView view)
        {
            view.DamageGetted -= OnAsteroidDamageGetted;
            view.Died -= OnDied;
        }
    }
}
