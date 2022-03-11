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
        public float speed = 15f;
        private Rigidbody2D rigidbody2D;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            rigidbody2D.velocity = transform.right * speed;
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
            //var ev = Schedule<PlayerEnemyCollision>();
            //ev.player = player;
        }
    }
}
    
