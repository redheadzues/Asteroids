using Assets.Source.CodeBase.Entities.EntityComponents;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IScoreService : IService
    {
        void AddEntity(EntityView entity);
        int GetScore();
        void Reset();
    }
}
