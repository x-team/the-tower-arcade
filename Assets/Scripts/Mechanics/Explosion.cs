using UnityEngine;
using Platformer.Gameplay;
using System.Collections;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    // <summary>
    /// An explosion collider
    /// </summary>
    public class Explosion : MonoBehaviour
    {
        public float explosionDuration = 2;

        private void Start()
        {
            StartCoroutine(WaitToDestroy());
        }

        private IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(explosionDuration);
            Destroy(gameObject);
        }

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