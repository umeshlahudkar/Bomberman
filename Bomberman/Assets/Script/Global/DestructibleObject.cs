using UnityEngine;
using Bomberman.Interface;
using Bomberman.EventSrvice;

namespace Bomberman.Global
{
    public class DestructibleObject : MonoBehaviour, IDamageble
    {
        public void TakeDamage()
        {
            EventService.Instance.InvokeOnDestructableKilledEvent();
            Destroy(gameObject);
        }
    }

}
