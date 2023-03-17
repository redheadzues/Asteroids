using UnityEngine;

namespace Assets.Source.CodeBase
{
    public class RandomPositionGetter
    {
        private readonly Camera _cameraMain;

        public RandomPositionGetter()
        {
            _cameraMain = Camera.main;
        }

        public Vector2 GetRandomPositionOutsideScreen()
        {
            Vector2 screenPosition = GetRandomPositiveUnitPoint();

            Vector2 additionalVector = GetRandomUnitVector();
            screenPosition += additionalVector;

            return _cameraMain.ViewportToWorldPoint(screenPosition);
        }

        public Vector2 GetRandomPositionInsideScreen()
        {
            Vector2 screenPosition = GetRandomPositiveUnitPoint();

            return _cameraMain.ViewportToWorldPoint(screenPosition);
        }

        private static Vector2 GetRandomPositiveUnitPoint()
        {
            Vector2 screenPosition = Random.insideUnitCircle;

            screenPosition.x = Mathf.Abs(screenPosition.x);
            screenPosition.y = Mathf.Abs(screenPosition.y);
            return screenPosition;
        }

        private Vector2 GetRandomUnitVector()
        {
            int randomInt = Random.Range(0, 4);

            switch(randomInt)
            {
                case 0:
                    return Vector2.up;
                case 1:
                    return Vector2.down;
                case 2:
                    return Vector2.left;
                case 3:
                    return Vector2.right;
            }

            return Vector2.up;

        }
    }
}
