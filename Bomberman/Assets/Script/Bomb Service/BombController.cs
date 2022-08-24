using UnityEngine;
using Bomberman.Audio;
using Bomberman.SO;
using Bomberman.PlayerService;
using Bomberman.Interface;
using Bomberman.Global;

namespace Bomberman.BombSrvice
{
    public class BombController
    {
        public BombModel bombModel { get; private set; }
        public BombView bombView { get; private set; }
        private PlayerController playerController;
        private bool isExplode;
        private Coroutine coroutine;
        private ParticleSystem explosionParticle;

        public BombController(BombSO bombSO, Transform spawnPosition, PlayerController playerController)
        {
            bombModel = new BombModel(bombSO);
            bombView = GameObject.Instantiate<BombView>(bombSO.bombViewPrefab, spawnPosition.position, Quaternion.identity);

            bombView.SetBombController(this);
            explosionParticle = GameObject.Instantiate(bombModel.explosionParticle);

            StartExplosionTimer();
            this.playerController = playerController;
            isExplode = false;
        }

        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(bombView.transform.position, bombModel.explosionRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                IDamageble damageble = colliders[i].gameObject.GetComponent<IDamageble>();
                if (damageble != null)
                {
                    damageble.TakeDamage();
                }
            }
            AudioManager.Instance.PlaySFXAudio(SoundType.BombExplosion);
            PlayParticleSystem();
            isExplode = true;
            Disable();
        }
        
        public void Enable(Vector3 spwanPosition)
        {
            bombView.gameObject.transform.position = spwanPosition;
            bombView.gameObject.SetActive(true);
            StartExplosionTimer();
        }

        private void StartExplosionTimer()
        {
            if (coroutine != null)
            {
                bombView.StopCoroutine(coroutine);
            }
            coroutine = bombView.StartCoroutine(bombView.StartExplosionTimer());
        }

        private void Disable()
        {
            if (coroutine != null)
            {
                bombView.StopCoroutine(coroutine);
            }
            if (playerController != null) playerController.SetCanPlaceBomb(isExplode);
            bombView.gameObject.SetActive(false);
            ObjectPool<BombController>.Instance.ReturnToPool(this);
        }

        private void PlayParticleSystem()
        {
            explosionParticle.transform.position = bombView.transform.position;
            explosionParticle.Play();
        }
    }
}

