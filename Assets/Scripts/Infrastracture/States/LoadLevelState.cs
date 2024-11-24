using CodeBase.GameLogic;
using CodeBase.GameLogic.CameraLogic;
using CodeBase.GameLogic.UILogic;
using CodeBase.Hero;
using CodeBase.Infrastracture.PersistanceProgress;
using System;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string SceneName = "Main";
        private const string InitialPointTag = "InitialPoint";
        private const string EnemySpawnerTage = "EnemySpawner";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistanceProgresService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, 
            IPersistanceProgresService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        private void OnLoadLevel()
        {
            _gameFactory.CleanUp();
            InitGameWorld();
            InitSpawners();
            InformProgressReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitSpawners()
        {
            foreach(var spawner in GameObject.FindGameObjectsWithTag(EnemySpawnerTage))
            {
               EnemySpawner enemySpawner = spawner.GetComponent<EnemySpawner>();
                _gameFactory.Register(enemySpawner);
            }
        }

        private void InformProgressReaders()
        {
            foreach(var reader in _gameFactory.ReadProgresses)
            {
                reader.LoadProgress(_progressService.PlayerProgress);
            }
        }

        private void InitGameWorld()
        {
            GameObject player = InitHero();
            
            InitHub(player);

            SetCameraFollow(player.transform);
        }

        private void InitHub(GameObject player)
        {
            GameObject hub = _gameFactory.CreateHub();
            ActorUI actor = hub.GetComponentInChildren<ActorUI>();
            actor.Construct(player.GetComponent<HeroHealth>());
        }

        private GameObject InitHero()
        {
            GameObject initialPoint = GameObject.FindGameObjectWithTag(InitialPointTag);
            GameObject player = _gameFactory.CreateHero(initialPoint);
            return player;
        }

        public void Enter(string levelName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(levelName, OnLoadLevel);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
       
        private void SetCameraFollow(Transform target)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .SetFollowTarget(target);
        }

        public void Update(){ }

    }
}