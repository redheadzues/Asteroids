using Assets.Source.CodeBase.Ship;
using Assets.Source.CodeBase.UI;
using Assets.Source.CodeBase.Weapons;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IUiFactory : IService
    {
        GameOverWindow CreateGameOverWindow(int score);
        void CreateHud(ShipModel model, LaserGun laser);
        void CreateRootCanvas();
    }
}