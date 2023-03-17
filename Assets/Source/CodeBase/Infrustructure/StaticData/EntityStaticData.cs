using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;
using System;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.StaticData
{
    [Serializable]
    public class EntityStaticData
    {
        public EntityType EntityType;
        public EntityView Prefab;
        public float Speed;
        public float SpawnTime;
        public DeathChecker DeathChecker;
    }
}