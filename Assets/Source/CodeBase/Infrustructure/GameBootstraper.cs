using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure
{
    public class GameBootstraper : MonoBehaviour
    {
        private Game _game;
        private Updater _updater;

        private void Awake()
        {
            _updater = new Updater();
            _game = new Game(_updater);
        }

        private void Update()
        {
            _updater.Update(Time.deltaTime);
        }
    }
}
