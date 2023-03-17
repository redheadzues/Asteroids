using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "AllEntityData", menuName = "StaticData/AllEntityData")]
    public class AllEntityData : ScriptableObject
    {
        public List<EntityStaticData> EntitiesData;
    }
}
