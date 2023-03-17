using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;

namespace Assets.Source.CodeBase.Systems
{
    public class UfoSpawnSystem : IUpdatable
    {
        private readonly IEntityFactory _entityFactory;
        private readonly float _spawnTime;
        private readonly RandomPositionGetter _positionOutsideScreenGetter;

        private float _timeUntilSpawn;

        public UfoSpawnSystem(IEntityFactory entityFactory, float spawnTime)
        {
            _entityFactory = entityFactory;
            _spawnTime = spawnTime;
            _timeUntilSpawn = spawnTime;
            _positionOutsideScreenGetter = new RandomPositionGetter();
        }

        public void Update(float tick)
        {
            _timeUntilSpawn -= tick;

            if (_timeUntilSpawn <= 0)
            {
                Entity entity = _entityFactory.Create(EntityType.Ufo);
                entity.Transform.Position.Value = _positionOutsideScreenGetter.GetRandomPositionOutsideScreen();
                _timeUntilSpawn = _spawnTime;
            }
        }
    }
}
