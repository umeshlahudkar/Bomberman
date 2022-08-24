using System.Collections;
using UnityEngine;
using Bomberman.EnemyService;

namespace Bomberman.BombSrvice
{
    public class BombView : MonoBehaviour
    {
        private BombController bombController;

        public void StartTimer()
        {
            StartCoroutine(StartExplosionTimer());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<EnemyView>() != null)
            {
                bombController.Explode();
            }
        }

        public IEnumerator StartExplosionTimer()
        {
            yield return new WaitForSeconds(bombController.bombModel.explosionDelay);
            bombController.Explode();
        }

        public void SetBombController(BombController bombController)
        {
            this.bombController = bombController;
        }
    }
}