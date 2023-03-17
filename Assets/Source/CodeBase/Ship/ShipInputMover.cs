using UnityEngine.InputSystem;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipInputMover : IUpdatable
    {
        private readonly PlayerInput _playerInput;
        private readonly InertionMove _inertionMove;
        private readonly ShipRotator _shipRotator;

        public ShipInputMover(InertionMove inertionMove, ShipRotator shipRotator)
        {
            _inertionMove = inertionMove;
            _shipRotator = shipRotator;
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }

        public void Update(float tick)
        {
            ChangeVelocity(tick);
            Rotate(tick);
        }

        private void ChangeVelocity(float tick)
        {
            if (CheckAccelerate() == true)
                _inertionMove.Accelerate(tick);
            else
                _inertionMove.SlowDown(tick);
        }

        private bool CheckAccelerate() => 
            _playerInput.Ship.MoveForward.phase == InputActionPhase.Performed;

        private void Rotate(float tick)
        {
            float direction = _playerInput.Ship.Rotate.ReadValue<float>();

            if (direction != 0)
                _shipRotator.Rotate(tick, direction);
        }
    }
}
