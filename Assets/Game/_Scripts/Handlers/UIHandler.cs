using TMPro;
using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Handlers
{
    public class UIHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _pauseUIGameObject;
        [SerializeField] private GameStateHandler _gameStateHandler;
        [SerializeField] private TMP_Text _highScoreTextBox;

        public void SetPauseUIState(bool state)
        {
            _pauseUIGameObject.SetActive(state);

            if (state) UpdateHighScoreText();
        }

        public void UpdateHighScoreText()
        {
            _highScoreTextBox.text = _gameStateHandler.GetHighScore().ToString();
        }
    }
}