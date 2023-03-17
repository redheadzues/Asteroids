namespace Assets.Source.CodeBase.Weapons
{
    public class SelfAddedClip : IUpdatable
    {
        private readonly int _maxAmmountProjectile = 5;
        private readonly int _projectileRefillTime = 7;
        
        private Observable<int> _currentProjectile;
        private float _remainingTimeToFillProjectile;

        public IReadOnlyObservable<int> CurrentProjectile => _currentProjectile;

        public SelfAddedClip()
        {
            _currentProjectile = new Observable<int>(_maxAmmountProjectile);
            _remainingTimeToFillProjectile = _projectileRefillTime;
        }

        public void SpendProjectile()
        {
            if( _currentProjectile.Value > 0)
                _currentProjectile.Value--;
        }

        public void Reset()
        {
            _currentProjectile.Value = _maxAmmountProjectile;
            _remainingTimeToFillProjectile = _projectileRefillTime;
        }

        private void AddProjectile()
        {
            _currentProjectile.Value++;
        }

        public void Update(float tick)
        {
            if (CurrentProjectile.Value < _maxAmmountProjectile)
            {
                _remainingTimeToFillProjectile -= tick;

                if(_remainingTimeToFillProjectile <= 0)
                {
                    AddProjectile();
                    _remainingTimeToFillProjectile = _projectileRefillTime;
                }
            }
        }
    }
}
