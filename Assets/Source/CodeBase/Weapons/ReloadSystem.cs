using Assets.Source.CodeBase.Infrustructure;

namespace Assets.Source.CodeBase.Weapons
{
    public class ReloadSystem : IUpdatable
    {
        private readonly float _reloadTime = 2;
        private Observable<float> _remainingTime = new Observable<float>(0);

        public bool IsReady { get; private set; }
        public IReadOnlyObservable<float> RemainingReloadTime => _remainingTime;

        public ReloadSystem()
        {
            IsReady = true;
        }

        public void StartReload()
        {
            IsReady = false;
            _remainingTime.Value = _reloadTime;
        }

        public void Reset()
        {
            IsReady = true;
            _remainingTime.Value = 0;
        }

        public void Update(float tick)
        {
            if (IsReady == false)
            {
                _remainingTime.Value -= tick;

                if (_remainingTime.Value <= 0)
                    IsReady = true;
            }
        }
    }
}
