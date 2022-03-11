using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    // <summary>
    /// A simple trigger for colliders
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
            //var ev = Schedule<PlayerEnemyCollision>();
            //ev.player = player;
        }
    }

}