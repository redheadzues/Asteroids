using Assets.Source.CodeBase.Infrustructure.Services;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Infrustructure
{
    public class Updater : IUpdater
    {
        private List<IUpdatable> _updatables = new List<IUpdatable>();

        private bool _isPaused;

        public void Pause() =>
            _isPaused = true;

        public void Start() => 
            _isPaused = false;

        public void AddListener(IUpdatable updatable)
        {
            if(_updatables.Contains(updatable) == false)
                _updatables.Add(updatable);
        }

        public void RemoveListener(IUpdatable updatable)
        {
            if(_updatables.Contains(updatable))
                _updatables.Remove(updatable);
        }

        public void Update(float tick)
        {
            if(_isPaused == false)
                _updatables.ForEach(updatable => updatable.Update(tick));
        }
    }
}
