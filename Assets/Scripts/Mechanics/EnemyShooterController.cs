using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    // <summary>
    /// A simple controller for shooter enemys
    /// </summary>
    ///
    [RequireComponent(typeof(EnemyController), typeof(Weapon))]
    public class EnemyShooterController : MonoBehaviour
    {
        private Weapon weapon;
        public int minInvervalInSeconds = 2;
        public int maxIntervalInSeconds = 5;

        public bool canShoot = true;

        void Awake()
        {
            weapon = GetComponent<Weapon>();
        }

        private void Start()
        {
            if (!canShoot) return;
            Attack();
        }

        public void EnableShoot()
        {
            if (canShoot) return;
            canShoot = true;
            Attack();
        }

        private void Attack()
        {
            if (!canShoot) return;
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            int interval = Random.Range(minInvervalInSeconds, maxIntervalInSeconds);
            yield return new WaitForSeconds(interval);
            weapon.Shoot();
            Attack();
        }
    }
}
   
