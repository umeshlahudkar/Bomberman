using UnityEngine;
using Bomberman.Audio;
using Bomberman.SO;
using Bomberman.EventSrvice;
using Bomberman.Global;

namespace Bomberman.EnemyService
{
    public class EnemyController
    {
        public EnemyView enemyView { get; private set; }
        public EnemyModel enemyModel { get; private set; }
        private EnemyService enemyService;
        private ParticleSystem enemyKillParticle;
        public bool canAttack { get; private set; }
        private Vector3 direction;

        public EnemyController(EnemySO enemySO, Vector3 spawnPosition, EnemyService enemyService)
        {
            enemyModel = new EnemyModel(enemySO);
            enemyView = GameObject.Instantiate<EnemyView>(enemySO.enemyViewPrefab, spawnPosition, Quaternion.identity);
            enemyKillParticle = GameObject.Instantiate(enemyModel.enemyKillParticle);
            this.enemyService = enemyService;
            enemyView.SetEnemyController(this);
            canAttack = true;
        }

        public void Move(Rigidbody rb)
        {
            direction = rb.transform.forward * enemyModel.movementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + direction);
        }

        public void Rotate(Rigidbody rb)
        {
            Quaternion rotate = Quaternion.Euler(0, rb.transform.rotation.y + 90, 0);
            rb.MoveRotation(rb.rotation * rotate);
        }

        public float GetDistance(Vector3 targetPosition)
        {
            return Vector3.Distance(enemyView.transform.position, targetPosition);
        }

        public void SetCanAttack(bool status)
        {
            canAttack = status;
        }

        public void Die()
        {
            enemyService.RemoveDisableEnemy(this);
            enemyView.gameObject.SetActive(false);
            PlayParticleSystem();
            ObjectPool<EnemyController>.Instance.ReturnToPool(this);
            AudioManager.Instance.PlaySFXAudio(SoundType.EnemyKill);
            EventService.Instance.InvokeOnDestructableKilledEvent();
        }

        private void PlayParticleSystem()
        {
            enemyKillParticle.transform.position = enemyView.transform.position;
            enemyKillParticle.Play();
        }
    }
}

