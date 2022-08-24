using UnityEngine;
using Bomberman.PlayerService;

namespace Bomberman.SO
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Object/Player")]
    public class PlayerSO : ScriptableObject
    {
        public PlayerView playerViewPrefab;
        public float movementSpeed;
    }
}
