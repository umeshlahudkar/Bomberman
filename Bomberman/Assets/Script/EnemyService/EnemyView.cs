using UnityEngine;
using Bomberman.Interface;
using Bomberman.PlayerService;

namespace Bomberman.EnemyService
{
    public class EnemyView : MonoBehaviour, IDamageble
    {
        public EnemyController enemyController { get; private set; }
        [SerializeField] private Rigidbody rb;
        [SerializeField] private LayerMask layerMask;
        private bool isRotating;


        private void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, enemyController.enemyModel.rayCastMaxDistance, layerMask))
            {
                Collider collider = hitInfo.collider;
                PlayerView playerView = collider.gameObject.GetComponent<PlayerView>();

                if (enemyController.canAttack && playerView != null) { return; }

                if (collider != null &&
                   enemyController.GetDistance(collider.gameObject.transform.position) <= enemyController.enemyModel.distancefromObjectToRotate)
                {
                    isRotating = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (isRotating)
            {
                enemyController.Rotate(rb);
                isRotating = false;
            }
            else
            {
                enemyController.Move(rb);
            }
        }

        public void SetEnemyController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void TakeDamage()
        {
            enemyController.Die();
        }
    }
}

