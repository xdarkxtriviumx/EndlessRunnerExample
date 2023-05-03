using TMPro;
using UnityEngine;

namespace Aberranthian.EndlessRunner.Game.Handlers
{
    public class ScoreHandler : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float _pointsPerSecond = 1f;

        [Header("References")]
        [SerializeField] private TMP_Text _scoreTextBox;

        public int Score { get => _currentScore; }

        private int _currentScore;
        private float _elapsedTime;

        private void Awake()
        {
            _currentScore = 0;
            _elapsedTime = 0f;
        }

        private void Start()
        {
            UpdateScoreText();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            _currentScore = Mathf.FloorToInt(_elapsedTime * _pointsPerSecond);
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _scoreTextBox.text = _currentScore.ToString();
        }
    }
}