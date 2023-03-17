using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;
using UnityEngine;

namespace Assets.Source.CodeBase.Weapons
{
    public class LaserGun : Weapon, IUpdatable, IResetable
    {
        private readonly SelfAddedClip _clip;
        private readonly ReloadSystem _reload;

        public IReadOnlyObservable<float> RemainingReloadTime => _reload.RemainingReloadTime;
        public IReadOnlyObservable<int> CurrentProjectile => _clip.CurrentProjectile;

        public LaserGun(IEntityFactory factory, EntityType projectile) : base(factory, projectile)
        {
            _clip = new SelfAddedClip();
            _reload = new ReloadSystem();
        }

        public override void FireAtPoint(Vector2 position, Quaternion rotation)
        {

            if (_clip.CurrentProjectile.Value > 0 && _reload.IsReady)
            {
                _clip.SpendProjectile();
                _reload.StartReload();

                base.FireAtPoint(position, rotation);
            }
        }

        public void Update(float tick)
        {
            _reload.Update(tick);
            _clip.Update(tick);
        }

        public void Reset()
        {
            _clip.Reset();
            _reload.Reset();
        }
    }
}
