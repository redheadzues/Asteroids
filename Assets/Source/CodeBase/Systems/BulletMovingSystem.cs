using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Systems
{
    public class BulletMovingSystem : IUpdatable
    {
        private readonly IEntityKeeper _entityKeeper;
        private readonly float _bulletSpeed;


        public BulletMovingSystem(IEntityKeeper entityKeeper, float bulletSpeed)
        {
            _entityKeeper = entityKeeper;
            _bulletSpeed = bulletSpeed;
        }

        public void Update(float tick)
        {
            List<Entity> updatingBullets = _entityKeeper.GetAllEntityByType(EntityType.Bullet);

            foreach (var entity in updatingBullets)
            {
                entity.Transform.Position.Value += entity.Transform.Forward * _bulletSpeed * tick;
            }
        }
    }
}
