using UnityEngine;
using Bomberman.BombSrvice;

namespace Bomberman.SO
{
    [CreateAssetMenu(fileName = "BombSO", menuName = "Scriptable Object/Bomb")]
    public class BombSO : ScriptableObject
    {
        public BombView bombViewPrefab;
        public ParticleSystem bombExplosionParticle;
        public float explosionDelay;
        public float explosionRadius;
    }
}