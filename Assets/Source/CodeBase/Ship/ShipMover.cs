using UnityEngine;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipMover : IUpdatable
    {
        private readonly GameTransform _transform;
        private readonly Observable<Vector2> _velocity;

        public ShipMover(GameTransform transform, Observable<Vector2> inertMovement)
        {
            _transform = transform;
            _velocity = inertMovement;
        }

        public void Update(float tick)
        {
            _transform.Position.Value += _velocity.Value;
        }
    }
}
