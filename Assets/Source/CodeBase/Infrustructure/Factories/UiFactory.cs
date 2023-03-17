using Assets.Source.CodeBase.Infrustructure.DataProviders;
using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Ship;
using Assets.Source.CodeBase.UI;
using Assets.Source.CodeBase.Weapons;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.Factories
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetProvider _assetProvider;

        private Transform _rootCanvas;

        public UiFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void CreateRootCanvas() => 
            _rootCanvas = _assetProvider.Instantiate(Paths.RootCanvas).transform;

        public void CreateHud(ShipModel model, LaserGun laser)
        {
            GameObject hud = _assetProvider.Instantiate(Paths.HUD, _rootCanvas);

            hud.GetComponent<UiHud>()
                .Construct(model.Transform.Position, model.Transform.Rotation, model.Velocity, laser.RemainingReloadTime, laser.CurrentProjectile);
        }

        public GameOverWindow CreateGameOverWindow(int score)
        {
            GameObject window = _assetProvider.Instantiate(Paths.GameOverWindow, _rootCanvas);

            GameOverWindow gameOverWindow = window.GetComponent<GameOverWindow>();
            gameOverWindow.Construct(score);

            return gameOverWindow;
        }
    }
}