using Assets.Source.CodeBase.Infrustructure.Services;

namespace Assets.Source.CodeBase.Infrustructure.States
{
    public class GameLoopState : IState
    {
        private readonly IUpdater _updater;

        public GameLoopState(IUpdater updater)
        {
            _updater = updater;
        }

        public void Enter()
        {
            _updater.Start();
        }
    }
}
