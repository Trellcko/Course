using CodeBase.UILogic;
using System;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public class LoadLevelState : IState
    {
        private const string SceneName = "Main";
        private const string InitialPointTag = "InitialPoint";
        private const string HetoPrefabPath = "Prefabs/Characters/Hero";
        private const string HudPrefabPath = "Prefabs/UI/Hud";
     
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(GameStateMachine gameStateMachine, 
            SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(SceneName, OnLoadLevel);
        }

        private void OnLoadLevel()
        {
            GameObject initialPoint = GameObject.FindGameObjectWithTag(InitialPointTag);

            GameObject player = Instantiate(HetoPrefabPath, 
                initialPoint.transform.position);

            Instantiate(HudPrefabPath);


            SetCameraFollow(player.transform);
            _gameStateMachine.Enter<GameLoopState>();
        }

        private GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab);
        }

        private GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab, at, Quaternion.identity);
        }

        private void SetCameraFollow(Transform target)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .SetFollowTarget(target);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}