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

        void Awake()
        {
            weapon = GetComponent<Weapon>();
        }

        private void Start()
        {
            Attack();
        }

        private void Attack()
        {
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
   
