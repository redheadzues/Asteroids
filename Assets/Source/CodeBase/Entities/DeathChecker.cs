using System;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Entities
{
    [Serializable]
    public class DeathChecker
    {
        public List<EntityType> _killers;

        public bool CheckKiller(EntityType type) =>
            _killers.Contains(type);
    }
}
