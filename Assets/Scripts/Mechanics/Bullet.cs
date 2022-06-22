using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    // <summary>
    /// A simple controller for bullet.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class Bullet : MonoBehaviour
    {
        public Vector2 speed = new Vector2(15f, 15f);
        private Rigidbody2D rigidbody2D;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            rigidbody2D.velocity = speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                OnHitPlayer(player);
            }
            OnCollide();
        }

        public virtual void OnCollide()
        {
            Destroy(gameObject);
        }

        public virtual void OnHitPlayer(PlayerController player)
        {
            var ev = Schedule<PlayerBulletCollision>();
            ev.player = player;
        }
    }
}
    
