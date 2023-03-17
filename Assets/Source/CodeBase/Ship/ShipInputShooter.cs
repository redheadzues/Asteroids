using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipInputShooter
    {
        private readonly PlayerInput _playerInput;
        private readonly ShipFireSystem _shipFireSystem;

        public ShipInputShooter(ShipFireSystem shipFireSystem)
        {
            _shipFireSystem = shipFireSystem;
            _playerInput = new PlayerInput();
            Enable();
        }

        public void Enable()
        {
            _playerInput.Enable();
            _playerInput.Ship.FirstWeaponShoot.performed += OnFirstWeaponShooted;
            _playerInput.Ship.SecondWeaponShoot.performed += OnSecondWeaponShooted;
        }

        public void Disable()
        {
            _playerInput.Disable();
            _playerInput.Ship.FirstWeaponShoot.performed -= OnFirstWeaponShooted;
            _playerInput.Ship.SecondWeaponShoot.performed -= OnSecondWeaponShooted;
        }

        private void OnSecondWeaponShooted(InputAction.CallbackContext obj) => 
            _shipFireSystem.ShootOnSecondSlot();

        private void OnFirstWeaponShooted(InputAction.CallbackContext obj) => 
            _shipFireSystem.ShootOnFirstWeapon();


    }
}
