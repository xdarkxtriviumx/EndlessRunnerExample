using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Aberranthian.EndlessRunner.Game
{
    public class SceneHandler : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float _restartDelaySeconds = 3f;

        private Coroutine _restartRoutine;

        public void RestartGame()
        {
            if (_restartRoutine != null) return;

            _restartRoutine = StartCoroutine(LoadSceneCoroutine(_restartDelaySeconds));
        }

        private IEnumerator LoadSceneCoroutine(float delay)
        {
            Debug.LogError($"Restarting game in {delay} seconds");

            yield return new WaitForSecondsRealtime(delay);

            _restartRoutine = null;
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}