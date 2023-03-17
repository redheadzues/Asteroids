namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IUpdater : IService
    {
        void Update(float tick);
        void AddListener(IUpdatable updatable);
        void RemoveListener(IUpdatable updatable);
        void Pause();
        void Start();
    }
}
