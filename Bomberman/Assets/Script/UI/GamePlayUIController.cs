using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Bomberman.Audio;
using Bomberman.Global;
using Bomberman.EventSrvice;

namespace Bomberman.UI
{
    public class GamePlayUIController : MonoBehaviour
    {
        [Header("Display object")]
        [SerializeField] private GameObject display;
        [SerializeField] private GameObject scoreDisplay;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI displayTitle;

        [Header("Position")]
        [SerializeField] private RectTransform scorePositionOnDisplay;
        [SerializeField] private RectTransform menuPositionOnDisplay;
        [SerializeField] private RectTransform initialScorePosition;
        [SerializeField] private RectTransform initialMenuPosition;

        [Header("Buttons")]
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button replayButton;
        [SerializeField] private Button menuButton;

        private void Start()
        {
            EventService.Instance.OnGameOver += GameOverOrGameWinDisplay;
            EventService.Instance.OnGameWin += GameOverOrGameWinDisplay;
        }

        private void OnDisable()
        {
            EventService.Instance.OnGameOver -= GameOverOrGameWinDisplay;
            EventService.Instance.OnGameWin -= GameOverOrGameWinDisplay;
        }

        public void OnGamePauseButtonClick()
        {
            Time.timeScale = 0;
            SetDisplayTitleName("Game Pause");
            pauseButton.interactable = false;
            resumeButton.gameObject.SetActive(true);
            replayButton.gameObject.SetActive(false);
            menuButton.gameObject.transform.position = menuPositionOnDisplay.position;
            display.gameObject.SetActive(true);
            AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClick);
            AudioListener.pause = true;
        }

        public void GameOverOrGameWinDisplay(string info)
        {
            Time.timeScale = 0;
            SetDisplayTitleName(info);
            pauseButton.interactable = false;
            replayButton.gameObject.SetActive(true);
            scoreDisplay.transform.position = scorePositionOnDisplay.position;
            menuButton.gameObject.transform.position = initialMenuPosition.position;
            display.gameObject.SetActive(true);
            AudioManager.Instance.PlayBackGroundAudio(SoundType.GameWin);
        }

        public void OnResumeButtonClick()
        {
            Time.timeScale = 1;
            pauseButton.interactable = true;
            scoreDisplay.gameObject.transform.position = initialScorePosition.position;
            menuButton.gameObject.transform.position = initialMenuPosition.position;
            resumeButton.gameObject.SetActive(false);
            replayButton.gameObject.SetActive(false);
            display.gameObject.SetActive(false);
            AudioListener.pause = false;
            AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClick);
        }

        private void SetDisplayTitleName(string name)
        {
            displayTitle.text = name;
        }

        public void OnReplayButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)scene.GamePlay);
            AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClick);
            AudioManager.Instance.PlayBackGroundAudio(SoundType.GamePlayScene);
        }

        public void OnMenuButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene((int)scene.Lobby);
            AudioListener.pause = false;
            AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClick);
            AudioManager.Instance.PlayBackGroundAudio(SoundType.LobbyScene);
        }
    }
}
