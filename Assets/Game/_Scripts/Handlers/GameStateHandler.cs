using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Handlers
{
    public class GameStateHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private UIHandler _uIHandler;
        [SerializeField] private ScoreHandler _scoreHandler;
        [SerializeField] private SaveHandler _saveHandler;
        [SerializeField] private SceneHandler _sceneHandler;

        private bool _isPaused = false;

        private void OnEnable()
        {
            _inputHandler.PausePressed += TogglePause;
        }

        private void OnDisable()
        {
            _inputHandler.PausePressed -= TogglePause;
        }

        public void HandleGameOver()
        {
            Time.timeScale = 0f;
            CheckUpdateHighScore();
            _inputHandler.DisablePlayerControls();
            _sceneHandler.RestartGame();
        }

        public void CheckUpdateHighScore()
        {
            if (_scoreHandler.Score > GetHighScore()) _saveHandler.SaveScore(_scoreHandler.Score);
        }

        public int GetHighScore()
        {
            return _saveHandler.LoadScore();
        }

        public void ResetHighScore()
        {
            _saveHandler.SaveScore(0);
            _uIHandler.UpdateHighScoreText();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void TogglePause()
        {
            _isPaused = !_isPaused;

            _uIHandler.SetPauseUIState(_isPaused);

            Time.timeScale = _isPaused ? 0f : 1f;
        }
    }
}