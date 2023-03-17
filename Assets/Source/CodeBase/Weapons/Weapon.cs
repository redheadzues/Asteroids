using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;
using UnityEngine;

namespace Assets.Source.CodeBase.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private readonly IEntityFactory _factory;
        private readonly EntityType _projectile;

        protected Weapon(IEntityFactory factory, EntityType projectile)
        {
            _factory = factory;
            _projectile = projectile;
        }

        public virtual void FireAtPoint(Vector2 position, Quaternion rotation)
        {
            Entity projectile = _factory.Create(_projectile);
            projectile.Transform.Position.Value = position;
            projectile.Transform.Rotation.Value = rotation;
        }
    }
}
