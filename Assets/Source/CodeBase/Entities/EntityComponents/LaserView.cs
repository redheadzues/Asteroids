using System.Collections;
using UnityEngine;

namespace Assets.Source.CodeBase.Entities.EntityComponents
{
    public class LaserView : EntityView
    {
        [SerializeField] private float _desctuctTime;

        private void Start()
        {
            StartCoroutine(OnDestructTimer(_desctuctTime));
        }

        private IEnumerator OnDestructTimer(float time)
        {
            yield return new WaitForSeconds(time);
            Die();
        }
    }
}
