using UnityEngine;
using Bomberman.SO;

namespace Bomberman.BombSrvice
{
    public class BombModel
    {
        public float explosionRadius { get; private set; }
        public float explosionDelay { get; private set; }
        public ParticleSystem explosionParticle { get; private set; }

        public BombModel(BombSO bombSO)
        {
            explosionDelay = bombSO.explosionDelay;
            explosionRadius = bombSO.explosionRadius;
            explosionParticle = bombSO.bombExplosionParticle;
        }
    }
}
