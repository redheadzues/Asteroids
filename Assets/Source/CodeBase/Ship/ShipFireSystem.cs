using Assets.Source.CodeBase.Weapons;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipFireSystem
    {
        private readonly GameTransform _parrentTransform;

        private IWeapon _firstWeapon;
        private IWeapon _secondWeapon;

        public IWeapon FirstWeapon => _firstWeapon;
        public IWeapon SecondWeapon => _secondWeapon;

        public ShipFireSystem(GameTransform parrentTransform)
        {
            _parrentTransform = parrentTransform;
        }


        public void SetFirstWeapon(IWeapon weapon) => 
            _firstWeapon = weapon;

        public void SetSecondWeapon(IWeapon weapon) => 
            _secondWeapon = weapon;

        public void ShootOnFirstWeapon() => 
            _firstWeapon.FireAtPoint(_parrentTransform.Position.Value, _parrentTransform.Rotation.Value);

        public void ShootOnSecondSlot() => 
            _secondWeapon.FireAtPoint(_parrentTransform.Position.Value, _parrentTransform.Rotation.Value);
    }
}
