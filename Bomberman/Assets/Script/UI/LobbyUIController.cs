using UnityEngine;
using UnityEngine.SceneManagement;
using Bomberman.Audio;
using Bomberman.Global;

namespace Bomberman.UI
{
    public class LobbyUIController : MonoBehaviour
    {
        public void OnPlayButtonClick()
        {
            SceneManager.LoadScene((int)scene.GamePlay);
            AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClick);
            AudioManager.Instance.PlayBackGroundAudio(SoundType.GamePlayScene);
        }

        public void OnQuitButtonClick()
        {
            Application.Quit();
            AudioManager.Instance.PlaySFXAudio(SoundType.ButtonClick);
        }
    }
}


