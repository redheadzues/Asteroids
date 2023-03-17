using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Infrustructure.States;

namespace Assets.Source.CodeBase.Infrustructure
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;

        public Game(IUpdater updater)
        {
            _gameStateMachine = new GameStateMachine(new AllServices(), updater);
            _gameStateMachine.Enter<BootstrapState>();
        }
    }

}