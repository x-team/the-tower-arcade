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
        public float intervalToShoot = 0.5f;
        public Vector2 speed = new Vector2(15f, 15f);

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
                GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet bullet = bulletObject.GetComponent<Bullet>();
                bullet.speed = speed;
                yield return new WaitForSeconds(intervalToShoot);
            }

            isShooting = false;
        }

        private Vector3 CalculateLinePoint(float t, Vector2 speed)
        {
            float g = Mathf.Abs(Physics2D.gravity.y);
            float x = speed.x * t;
            float y = (speed.y * t) - (g * Mathf.Pow(t, 2) / 2);
            return new Vector3(x + firePoint.position.x, y + firePoint.position.y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;

            int maxSteps = 30;
            float timeScale = 0.05f;
            Vector2 currentPosition = firePoint.position;

            for (var i = 0; i <= maxSteps; i++)
            {
                Vector2 nextPosition = CalculateLinePoint(i * timeScale, speed);
                Gizmos.DrawLine(currentPosition, nextPosition);
                currentPosition = nextPosition;
            }
        }
    }
}
