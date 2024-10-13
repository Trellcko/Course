using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infastructure
{
    public class SceneLoader
    {
        private readonly ICorountineRunner _corountineRunner;

        public SceneLoader(ICorountineRunner corountineRunner)
        {
            _corountineRunner = corountineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            _corountineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if(SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            onLoaded?.Invoke();
        }
    }
}