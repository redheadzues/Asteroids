using Assets.Source.CodeBase.Entities.EntityComponents;

namespace Assets.Source.CodeBase.Entities
{
    public class Entity
    {
        public readonly GameTransform Transform;
        public readonly EntityView EntityView;

        public Entity(GameTransform transform, EntityView entityView)
        {
            Transform = transform;
            EntityView = entityView;
        }
    }
}