using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GAME_MAIN.CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICorutibeRunner _corutineRunner;

        public SceneLoader(ICorutibeRunner coroutineRunner) =>
            _corutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
            _corutineRunner.StartCoroutine(LoadeScene(name,onLoaded));
        
        public IEnumerator LoadeScene(string nextScene, Action onLoaded = null)
        {
            Debug.Log("Load"+nextScene);
            /*if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }*/
            AsyncOperation waitNextScene=SceneManager.LoadSceneAsync(nextScene);
            while (!waitNextScene.isDone)
                yield return null;
            onLoaded?.Invoke();
          
        }
    }
}
