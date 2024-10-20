using CodeBase.UILogic;
using System;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string SceneName = "Main";
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        private void OnLoadLevel()
        {
            GameObject initialPoint = GameObject.FindGameObjectWithTag(InitialPointTag);
            GameObject player = _gameFactory.CreateHero(initialPoint);
            _gameFactory.CreateHub();


            SetCameraFollow(player.transform);
            _gameStateMachine.Enter<GameLoopState>();
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