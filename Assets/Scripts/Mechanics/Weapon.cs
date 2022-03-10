using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    // <summary>
    /// A simple controller for weapon. Spawn bullets within intervals
    /// </summary>
    ///
    [RequireComponent(typeof(Transform))]
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        public int bulletsPerShoot = 1;
        public float interval = 0.5f;

        private bool isShooting = false;

        public void Shoot()
        {
            if (isShooting) return;
            StartCoroutine(SpawnBullets());
        }

        private IEnumerator SpawnBullets()
        {
            isShooting = true;

            for (int i = 0; i < bulletsPerShoot; i++)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                yield return new WaitForSeconds(interval);
            }

            isShooting = false;
        }
    }
}
