using UnityEngine;

namespace Assets.Source.CodeBase.Entities.EntityComponents
{
    public class EntityActivityChecker 
    {
        private readonly Camera _camera;
        private readonly Transform _transform;
        private bool _wasVisible;
        private float _timeToDestroyWithoutVisible = 20;

        public EntityActivityChecker(Camera camera, Transform transform)
        {
            _camera = camera;
            _transform = transform;
        }

        public bool IsGoodTimeToDie(float deltaTime)
        {
            Vector3 viewPortPosition = _camera.WorldToViewportPoint(_transform.position);

            if (_wasVisible == false)
            {
                _wasVisible = IsInsideScreen(viewPortPosition);
                _timeToDestroyWithoutVisible -= deltaTime;

                if (_timeToDestroyWithoutVisible <= 0)
                    return true;
            }

            if (_wasVisible == true && IsOutsideScreen(viewPortPosition))
                return true;

            return false;
        }

        private bool IsInsideScreen(Vector2 viewPortPosition)
        {
            if (viewPortPosition.x > 0 && viewPortPosition.x < 1)
                return true;
            if (viewPortPosition.y > 0 && viewPortPosition.y < 1)
                return true;

            return false;
        }

        private bool IsOutsideScreen(Vector2 viewPortPosition)
        {
            if (viewPortPosition.x < -0.5f || viewPortPosition.x > 1.5f)
                return true;
            if (viewPortPosition.y < -0.5f || viewPortPosition.y > 1.5f)
                return true;

            return false;
        }
    }
}
