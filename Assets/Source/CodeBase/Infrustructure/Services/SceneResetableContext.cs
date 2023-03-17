using System;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public class SceneResetableContext : ISceneContext
    {
        private Dictionary<Type, IResetable> _resetables = new Dictionary<Type, IResetable>();

        public void AddContext(Type type, IResetable resetable) => 
            _resetables.Add(type, resetable);

        public T GetContext<T>()  where T : class, IResetable  => 
            _resetables.TryGetValue(typeof(T), out IResetable resetable) 
            ? 
            resetable as T 
            : null;


        public void ResetAll()
        {
            foreach(IResetable resetable in _resetables.Values)
                resetable.Reset();
        }
    }

    public interface ISceneContext : IService
    {
        void AddContext(Type type, IResetable resetable);
        T GetContext<T>() where T : class, IResetable;
        void ResetAll();
    }

    public interface IResetable
    {
        void Reset();
    }
}
