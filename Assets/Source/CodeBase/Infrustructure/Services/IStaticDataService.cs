using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Infrustructure.StaticData;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        ShipStaticData GetShipStaticData();
        EntityStaticData GetEntityData(EntityType entityType);
    }
}