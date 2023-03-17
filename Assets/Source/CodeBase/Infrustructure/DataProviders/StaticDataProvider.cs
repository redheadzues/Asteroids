using Assets.Source.CodeBase.Infrustructure.StaticData;
using UnityEngine;
using System.Linq;
using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.Services;

namespace Assets.Source.CodeBase.Infrustructure.DataProviders
{
    public class StaticDataProvider : IStaticDataService
    {

        private ShipStaticData _shipData;
        private AllEntityData _allEntityData;

        public EntityStaticData GetEntityData(EntityType entityType) =>
            _allEntityData.EntitiesData.FirstOrDefault(x => x.EntityType == entityType);

        public ShipStaticData GetShipStaticData() =>
            _shipData;

        public void Load()
        {
            _shipData = Resources.Load<ShipStaticData>(Paths.ShipData);
            _allEntityData = Resources.Load<AllEntityData>(Paths.AllEntityData);
        }
    }

}