using UnityEngine;

namespace Assets.Source.CodeBase.Ship
{
    public class InertionMove
    {
        private readonly ShipModel _model;

        public InertionMove(ShipModel model)
        {
            _model = model;
        }

        public void Accelerate(float tick)
        {
            _model.Velocity.Value += _model.Transform.Forward * _model.Acceleration * tick;
            _model.Velocity.Value = Vector2.ClampMagnitude(_model.Velocity.Value, _model.MaxSpeed);
        }

        public void SlowDown(float tick)
        {
            _model.Velocity.Value = Vector2.MoveTowards(_model.Velocity.Value, Vector2.zero, _model.Deceleration * tick);

        }
    }
}
