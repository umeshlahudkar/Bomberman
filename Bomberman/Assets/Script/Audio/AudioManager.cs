using System;
using UnityEngine;
using Bomberman.Global;

namespace Bomberman.Audio
{
    public class AudioManager : GenericSingleton<AudioManager>
    {
        [SerializeField] private AudioSource backgroundAudioSource;
        [SerializeField] private AudioSource SFXAudioSource;

        [SerializeField] private Sound[] sounds;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            PlayBackGroundAudio(SoundType.LobbyScene);
        }

        public void PlayBackGroundAudio(SoundType soundType)
        {
            AudioClip clip = GetAudioClip(soundType);
            if (clip != null)
            {
                backgroundAudioSource.clip = clip;
                backgroundAudioSource.Play();
            }
        }

        public void PlaySFXAudio(SoundType soundType)
        {
            AudioClip clip = GetAudioClip(soundType);
            if (clip != null)
            {
                SFXAudioSource.PlayOneShot(clip);
            }
        }

        private AudioClip GetAudioClip(SoundType soundType)
        {
            Sound sound = Array.Find(sounds, item => item.soundType == soundType);
            if (sound != null)
            {
                return sound.audioClip;
            }

            return null;
        }
    }

    [Serializable]
    public class Sound
    {
        public SoundType soundType;
        public AudioClip audioClip;
    }

    public enum SoundType
    {
        None,
        LobbyScene,
        GamePlayScene,
        ButtonClick,
        BombExplosion,
        EnemyKill,
        GameWin
    }
}
