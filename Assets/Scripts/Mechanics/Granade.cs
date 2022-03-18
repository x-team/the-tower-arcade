using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    // <summary>
    /// A simple controller for granade.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class Granade : Bullet {

        public GameObject explosionPrefab;
        public float secondsToExplode = 2;
        private bool exploded = false;

        public override void OnHitPlayer(PlayerController player){ }
        public override void OnCollide(){ }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (exploded) return;
            StartCoroutine(WaitToExplode());
        }

        private IEnumerator WaitToExplode()
        {
            yield return new WaitForSeconds(secondsToExplode);
            Explode();
        }

        private void Explode()
        {
            exploded = true;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}