using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;

namespace Assets.Source.CodeBase.Weapons
{
    public class Cannon : Weapon
    {
        public Cannon(IEntityFactory factory, EntityType projectile) : base(factory, projectile)
        {
        }
    }
}
