using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.CodeBase.Ship
{
    public class ShipModel : IResetable
    {
        public readonly GameTransform Transform;
        public readonly Observable<Vector2> Velocity;
        public readonly float Acceleration;
        public readonly float Deceleration;
        public readonly float MaxSpeed;
        public readonly float RotationSpeed;

        private readonly ShipStaticData _config;

        public ShipModel(ShipStaticData config)
        {
            _config = config;
            Acceleration = _config.Acceleration;
            Deceleration = _config.Deceleration;
            MaxSpeed = _config.MaxSpeed;
            RotationSpeed = _config.RotationSpeed;
            Transform = new GameTransform(_config.StartPosition, _config.StartRotation);
            Velocity = new Observable<Vector2>(Vector2.zero);
        }

        public void Reset()
        {
            Transform.Position.Value = _config.StartPosition;
            Transform.Rotation.Value = _config.StartRotation;
            Velocity.Value = Vector2.zero;
        }
    }
}
