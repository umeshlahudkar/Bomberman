using Bomberman.EnemyService;
using Bomberman.Interface;
using UnityEngine;

namespace Bomberman.PlayerService
{
    public class PlayerView : MonoBehaviour, IDamageble
    {
        private PlayerController playerController;
        [SerializeField] private Rigidbody rb;
        private float xInput;
        private float yInput;

        private void Update()
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerController.PlantBomb();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyView>() != null)
            {
                TakeDamage();
            }
        }

        public void SetPlayerController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        private void FixedUpdate()
        {
            playerController.Move(rb, xInput, yInput);
        }

        public void TakeDamage()
        {
            playerController.Die();
            Destroy(gameObject);
        }
    }
}
