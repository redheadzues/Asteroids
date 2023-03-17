using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Infrustructure.States;
using System;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Infrustructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        public GameStateMachine(AllServices services, IUpdater updater)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services, updater),
                [typeof(SceneInitState)] = new SceneInitState(this, services),
                [typeof(GameLoopState)] = new GameLoopState(services.Get<IUpdater>()),
                [typeof(GameOverState)] = new GameOverState(this, services.Get<IUiFactory>(), services.Get<ISceneContext>(), services.Get<IUpdater>()),
                [typeof(RestartState)] = new RestartState(this, services.Get<ISceneContext>(), services.Get<IEntityKeeper>()),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            IState state = _states[typeof(TState)];
            state.Enter();
        }
    }
}
