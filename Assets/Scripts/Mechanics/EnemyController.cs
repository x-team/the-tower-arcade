using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public AudioClip ouch;

        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        internal Weapon weapon;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            weapon = GetComponent<Weapon>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        public void Kill()
        {
            _collider.enabled = false;
            control.enabled = false;

            if(weapon != null)
            {
                weapon.enabled = false;
            }

            Schedule<EnemyDestroy>(2).enemy = this;
        }

        public void Reset()
        {
            _collider.enabled = true;
            control.enabled = true;

            if (weapon != null)
            {
                weapon.enabled = true;
            }
        }

        public void DestroyInstance()
        {
            Destroy(gameObject);
        }

    }
}