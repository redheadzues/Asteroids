using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure;
using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Infrustructure.States;

namespace Assets.Source.CodeBase
{
    public class GameOverer : IResetable
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly EntityView _playerView;

        public GameOverer(GameStateMachine gameStateMachine, EntityView playerView)
        {
            _gameStateMachine = gameStateMachine;
            _playerView = playerView;
            _playerView.Died += OnPlayerDied;
        }

        public void Reset()
        {
            _playerView.Died += OnPlayerDied;
        }

        private void OnPlayerDied(EntityView view)
        {
            _playerView.Died -= OnPlayerDied;
            _gameStateMachine.Enter<GameOverState>();
        }
    }
}
