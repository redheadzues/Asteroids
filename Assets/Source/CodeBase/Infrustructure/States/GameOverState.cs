using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.UI;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.States
{
    public class GameOverState : IState
    {
        private readonly GameStateMachine _gamestateMachine;
        private readonly IUiFactory _uiFactory;
        private readonly ISceneContext _context;
        private readonly IUpdater _updater;

        private GameOverWindow _gameOverWindow;

        public GameOverState(GameStateMachine gamestateMachine, IUiFactory uiFactory, ISceneContext context, IUpdater updater)
        {
            _gamestateMachine = gamestateMachine;
            _uiFactory = uiFactory;
            _context = context;
            _updater = updater;
        }

        public void Enter()
        {
            _updater.Pause();
            int finalScore = _context.GetContext<Score>().GetScore();
            _gameOverWindow = _uiFactory.CreateGameOverWindow(finalScore);
            _gameOverWindow.RestartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            _gameOverWindow.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            Object.Destroy(_gameOverWindow.gameObject);
            _gamestateMachine.Enter<RestartState>();            
        }
    }
}
