using Assets.Source.CodeBase.Infrustructure.Services;

namespace Assets.Source.CodeBase.Infrustructure.States
{
    public class RestartState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneContext _context;
        private readonly IEntityKeeper _entityKeeper;

        public RestartState(GameStateMachine gameStateMachine, ISceneContext context, IEntityKeeper entityKeeper)
        {
            _gameStateMachine = gameStateMachine;
            _context = context;
            _entityKeeper = entityKeeper;
        }

        public void Enter()
        {
            _context.ResetAll();
            _entityKeeper.CleanUp();
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}
