using Assets.Source.CodeBase.Entities;
using Assets.Source.CodeBase.Entities.EntityComponents;
using Assets.Source.CodeBase.Infrustructure.Services;
using Assets.Source.CodeBase.Ship;
using Assets.Source.CodeBase.Systems;
using Assets.Source.CodeBase.Weapons;

namespace Assets.Source.CodeBase.Infrustructure.States
{
    public class SceneInitState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IShipFactory _shipFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IEntityKeeper _entityKeeper;
        private readonly IUpdater _updater;
        private readonly IEntityFactory _entityFactory;
        private readonly ISceneContext _sceneContext;
        private readonly IUiFactory _uiFactory;

        private ShipModel _ship;
        private EntityView _shipView;
        private LaserGun _laser;

        public SceneInitState(GameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _shipFactory = services.Get<IShipFactory>();
            _staticDataService = services.Get<IStaticDataService>();
            _entityKeeper = services.Get<IEntityKeeper>();
            _updater = services.Get<IUpdater>();
            _entityFactory = services.Get<IEntityFactory>();
            _uiFactory = services.Get<IUiFactory>();
            _sceneContext = services.Get<ISceneContext>();
        }

        public void Enter()
        {
            CreatePlayerShip();
            CreateGamePlaySystems();
            CreateHud();
            CreateGameOverer();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CreateGameOverer()
        {
            GameOverer gameOverer = new GameOverer(_gameStateMachine, _shipView);
            _sceneContext.AddContext(typeof(GameOverer), gameOverer);
        }

        private void CreateHud()
        {
            _uiFactory.CreateRootCanvas();
            _uiFactory.CreateHud(_ship, _laser);
        }

        private void CreateGamePlaySystems()
        {
            UfoMovingSystem ufoMovingSystem = new UfoMovingSystem(_entityKeeper, _ship.Transform.Position, _staticDataService.GetEntityData(EntityType.Ufo).Speed);
            UfoSpawnSystem ufoSpawnSystem = new UfoSpawnSystem(_entityFactory, _staticDataService.GetEntityData(EntityType.Ufo).SpawnTime);
            AsteroidMovingSystem asteroidMovingSystem = new AsteroidMovingSystem(_entityKeeper, _staticDataService.GetEntityData(EntityType.Asteroid).Speed, _staticDataService.GetEntityData(EntityType.PartOfAsteroid).Speed);
            AsteroidSpawnSystem asteroidSpawnSystem = new AsteroidSpawnSystem(_entityFactory, _staticDataService.GetEntityData(EntityType.Asteroid).SpawnTime);
            BulletMovingSystem bulletMovingSystem = new BulletMovingSystem(_entityKeeper, _staticDataService.GetEntityData(EntityType.Bullet).Speed);


            _updater.AddListener(ufoMovingSystem);
            _updater.AddListener(ufoSpawnSystem);
            _updater.AddListener(asteroidSpawnSystem);
            _updater.AddListener(asteroidMovingSystem);
            _updater.AddListener(bulletMovingSystem);
        }

        private void CreatePlayerShip()
        {
            _ship = _shipFactory.CreateShip();
            _shipView = _shipFactory.CreateShipView();
            _sceneContext.AddContext(typeof(ShipModel), _ship);

            CreateShipFireSystem();
        }

        private void CreateShipFireSystem()
        {
            ShipFireSystem fireSystem = _shipFactory.CreateShipFireSystem();

            Cannon cannon = new Cannon(_entityFactory, EntityType.Bullet);
            fireSystem.SetFirstWeapon(cannon);

            _laser = new LaserGun(_entityFactory, EntityType.Laser);
            _updater.AddListener(_laser);
            _sceneContext.AddContext(typeof(LaserGun), _laser);
            fireSystem.SetSecondWeapon(_laser);
        }
    }
}
