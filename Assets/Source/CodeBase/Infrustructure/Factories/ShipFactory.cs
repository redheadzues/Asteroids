using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Infrustructure.StaticData;
using Assets.Source.CodeBase.Ship;

namespace Assets.Source.CodeBase.Infrustructure.Factories
{
    public class ShipFactory : IShipFactory
    {
        private readonly IUpdater _updater;
        private readonly IStaticDataService _staticDataService;
        private readonly IViewFactory _viewFactory;

        private ShipModel _shipModel;
        private EntityView _shipView;
        private ShipStaticData _shipConfig;

        public ShipFactory(IUpdater updater, IStaticDataService staticDataService, IViewFactory viewFactory)
        {
            _updater = updater;
            _staticDataService = staticDataService;
            _viewFactory = viewFactory;
        }

        public ShipModel CreateShip()
        {
            _shipConfig = _staticDataService.GetShipStaticData();

            ShipModel shipModel = new ShipModel(_shipConfig);
            InertionMove inertionMove = new InertionMove(shipModel);
            ShipMover shipMover = new ShipMover(shipModel.Transform, shipModel.Velocity);
            ShipRotator shipRotator = new ShipRotator(shipModel.Transform, shipModel.RotationSpeed);
            ShipPositionClamper positionClamper = new ShipPositionClamper(shipModel.Transform);
            ShipInputMover shipIntup = new ShipInputMover(inertionMove, shipRotator);

            _updater.AddListener(shipMover);
            _updater.AddListener(positionClamper);
            _updater.AddListener(shipIntup);

            _shipModel = shipModel;            

            return shipModel;
        }

        public ShipFireSystem CreateShipFireSystem()
        {
            if (_shipModel == null)
                return null;

            ShipFireSystem fireSystem = new ShipFireSystem(_shipModel.Transform);
            ShipInputShooter shooter = new ShipInputShooter(fireSystem);

            return fireSystem;
        }

        public EntityView CreateShipView()
        {
            _shipView = _viewFactory.CreateEntityView(_shipModel.Transform, _shipConfig.EntityType, null);

            return _shipView;
        }
    }   
}
