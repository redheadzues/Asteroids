using UnityEngine;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipRotator
    {
        private readonly GameTransform _transform;
        private readonly float _rotationSpeed;

        private float _rotation;

        public ShipRotator(GameTransform transform, float rotationSpeed)
        {
            _transform = transform;
            _rotationSpeed = rotationSpeed;
        }

        public void Rotate(float tick, float direction)
        {
            _rotation = _transform.Rotation.Value.eulerAngles.z;
            CalculateRotate(tick, direction);
            ClampRotation();

            _transform.Rotation.Value = Quaternion.Euler(0, 0, _rotation);
        }

        private void CalculateRotate(float tick, float direction) => 
            _rotation += direction * tick * _rotationSpeed;

        private void ClampRotation() => 
            _rotation = Mathf.Repeat(_rotation, 360);
    }
}
