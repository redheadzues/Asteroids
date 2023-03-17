using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.CodeBase.Entities
{
    public class EntityKeeper : IEntityKeeper
    {
        private Dictionary<EntityType, List<Entity>> _entities = new Dictionary<EntityType, List<Entity>>();

        public event Action Destroy;

        public void AddEntity(Entity entity)
        {
            if (_entities.ContainsKey(entity.EntityView.EntityType) == false)
                _entities.Add(entity.EntityView.EntityType, new List<Entity>());

            if (_entities[entity.EntityView.EntityType].Contains(entity) == false)
            {
                _entities[entity.EntityView.EntityType].Add(entity);
                entity.EntityView.Died += OnEntityDied;
            }
        }

        public void CleanUp()
        {
            Destroy?.Invoke();
        }

        public List<Entity> GetAllEntityByType(EntityType type)
        {
            List<Entity> output = new List<Entity>();

            if (_entities.ContainsKey(type))
                output = _entities[type];

            return output;
        }

        private void OnEntityDied(EntityView view)
        {
            view.Died -= OnEntityDied;

            Entity entity = _entities[view.EntityType].First(x => x.EntityView == view);

            _entities[view.EntityType].Remove(entity);
            GameObject.Destroy(view.gameObject);
        }
    }
}
