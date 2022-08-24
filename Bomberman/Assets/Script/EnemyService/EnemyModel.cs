using UnityEngine;
using Bomberman.SO;

namespace Bomberman.EnemyService
{
    public class EnemyModel
    {
        public float rayCastMaxDistance { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float distancefromObjectToRotate { get; private set; }
        public ParticleSystem enemyKillParticle { get; private set; }

        public EnemyModel(EnemySO enemySO)
        {
            rayCastMaxDistance = enemySO.rayCastMaxDistance;
            movementSpeed = enemySO.movementSpeed;
            distancefromObjectToRotate = enemySO.distanceFromObjectToRotate;
            enemyKillParticle = enemySO.enemyKillParticle;
        }
    }
}

