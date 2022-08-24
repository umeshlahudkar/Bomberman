using UnityEngine;
using Bomberman.EnemyService;

namespace Bomberman.SO
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Object/Enemy")]
    public class EnemySO : ScriptableObject
    {
        public EnemyView enemyViewPrefab;
        public ParticleSystem enemyKillParticle;
        public float rayCastMaxDistance;
        public float movementSpeed;
        public float distanceFromObjectToRotate;
    }
}
