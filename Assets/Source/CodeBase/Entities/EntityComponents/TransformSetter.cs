using UnityEngine;

namespace Assets.Source.CodeBase.Entities.EntityComponents
{
    public class TransformSetter : MonoBehaviour
    {
        private IReadOnlyObservable<Vector2> _position;
        private IReadOnlyObservable<Quaternion> _rotation;

        private void OnDisable()
        {
            if (_position != null)
                _position.ValueChanged -= OnPositionChanged;

            if (_rotation != null)
                _rotation.ValueChanged -= OnRotationChanged;
        }

        public void Construct(IReadOnlyObservable<Vector2> position, IReadOnlyObservable<Quaternion> rotation)
        {
            _position = position;
            _rotation = rotation;

            OnPositionChanged(position.Value);
            OnRotationChanged(rotation.Value);

            _position.ValueChanged += OnPositionChanged;
            _rotation.ValueChanged += OnRotationChanged;
        }

        private void OnRotationChanged(Quaternion rotation) =>
            transform.rotation = rotation;

        private void OnPositionChanged(Vector2 position) =>
            transform.position = position;
    }
}
