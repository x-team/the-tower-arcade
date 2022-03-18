using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    // <summary>
    /// An explosion collider
    /// </summary>
    public class Explosion : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                OnHitPlayer(player);
            }
        }

        public virtual void OnHitPlayer(PlayerController player)
        {
            var ev = Schedule<PlayerBulletCollision>();
            ev.player = player;
        }
    }

}