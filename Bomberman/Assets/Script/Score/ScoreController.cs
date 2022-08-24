using UnityEngine;
using Bomberman.EventSrvice;
using TMPro;

namespace Bomberman.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private string highestScore = "HighScore";
        private int score;
        private int highScore;

        private void Start()
        {
            EventService.Instance.OnDestructableKilled += UpdateScore;
            highScore = GetHighScore();
            DisplayScore();
            DisplayHighScore();
        }

        private void OnDisable()
        {
            EventService.Instance.OnDestructableKilled -= UpdateScore;
        }
        public void UpdateScore()
        {
            score += 10;
            DisplayScore();

            if (score > highScore)
            {
                SetHighScore();
                highScore = GetHighScore();
                DisplayHighScore();
            }
        }

        private void DisplayScore()
        {
            scoreText.text = score.ToString();
        }

        private void DisplayHighScore()
        {
            highScoreText.text = highScore.ToString();
        }

        private int GetHighScore()
        {
            return PlayerPrefs.GetInt(highestScore);
        }

        private void SetHighScore()
        {
            PlayerPrefs.SetInt(highestScore, score);
        }
    }
}
