using System;
using UnityEngine;

namespace Assets.Source.CodeBase.Entities.EntityComponents
{
    public class EntityView : MonoBehaviour
    {
        protected DeathChecker _deathChecker;
        private EntityType _type;
        private EntityActivityChecker _activityChecker;
        private IRemoteCommander _remoteCommander;

        public EntityType EntityType => _type;
        public event Action<EntityView> Died;
        public event Action<EntityView> DamageGetted;

        public void Construct(EntityType type, DeathChecker checker, IRemoteCommander comander)
        {
            _type = type;
            _deathChecker = checker;
            _activityChecker = new EntityActivityChecker(Camera.main, transform);

            if(comander != null)
            {
                _remoteCommander = comander;
                _remoteCommander.Destroy += OnComandDestroy;
            }
        }

        private void OnDisable()
        {
            if(_remoteCommander != null)
                _remoteCommander.Destroy -= OnComandDestroy;
        }

        private void Update()
        {
            if (_activityChecker.IsGoodTimeToDie(Time.deltaTime))
                Die();
        }

        protected void Die() => 
            Died?.Invoke(this);

        private void OnComandDestroy() =>
            Die();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out EntityView view))
                if (_deathChecker.CheckKiller(view.EntityType))
                {
                    DamageGetted?.Invoke(this);
                    Die();
                }
        }
    }
}
