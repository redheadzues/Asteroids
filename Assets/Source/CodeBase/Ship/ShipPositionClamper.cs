using UnityEngine;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipPositionClamper : IUpdatable
    {
        private readonly GameTransform _transform;
        private readonly Camera _camera;

        public ShipPositionClamper(GameTransform transform)
        {
            _transform = transform;
            _camera = Camera.main;
        }

        public void Update(float tick)
        {
            Vector3 clampedPosition = _camera.WorldToViewportPoint(_transform.Position.Value);
            clampedPosition.x = Mathf.Repeat(clampedPosition.x, 1);
            clampedPosition.y = Mathf.Repeat(clampedPosition.y, 1);
            clampedPosition = _camera.ViewportToWorldPoint(clampedPosition);

            _transform.Position.Value = clampedPosition;
        }
    }
}
