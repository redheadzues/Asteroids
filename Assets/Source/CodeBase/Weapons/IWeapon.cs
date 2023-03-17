using UnityEngine;

namespace Assets.Source.CodeBase.Weapons
{
    public interface IWeapon
    {
        void FireAtPoint(Vector2 position, Quaternion rotation);
    }
}
