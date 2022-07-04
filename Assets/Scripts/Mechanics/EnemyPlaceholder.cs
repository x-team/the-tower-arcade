using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Mechanics
{
    public class EnemyPlaceholder : MonoBehaviour
    {
        public enum EnemyType
        {
            Drogo,
            Monodrone,
            Hustman,
            Spyderbot
        }

        public EnemyType type;
        private EnemyController enemy;
        public Vector2 weaponSpeed = new Vector2(0f, 0f);
        public PatrolPath patrolPath;
        public bool isFilled => enemy != null;

        public void Spawn(GameObject gameObject)
        {
            if (isFilled) return;

            EnemyController enemy = gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                this.enemy = enemy;
                enemy.transform.position = this.transform.position;
                enemy.Reset();

                Weapon weapon = enemy.GetComponent<Weapon>();

                if(weapon != null)
                {
                    weapon.speed = weaponSpeed;
                }

                PatrolPathController patrolPathController = enemy.GetComponent<PatrolPathController>();

                if(patrolPathController != null)
                {
                    patrolPathController.SetPath(patrolPath);
                }

                EnemyShooterController enemyShooterController = enemy.GetComponent<EnemyShooterController>();

                if (enemyShooterController != null)
                {
                    enemyShooterController.EnableShoot();
                }
            }
        }

        private void OnDrawGizmos()
        {
            switch (type)
            {
                case EnemyType.Drogo:
                    Gizmos.color = Color.cyan;
                    break;
                case EnemyType.Monodrone:
                    Gizmos.color = Color.red;
                    break;
                case EnemyType.Spyderbot:
                    Gizmos.color = Color.yellow;
                    break;
                case EnemyType.Hustman:
                    Gizmos.color = Color.blue;
                    break;

            }

            if (isFilled) return;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }

}
