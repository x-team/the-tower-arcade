using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class CameraTargetObject : MonoBehaviour
    {
        public Transform target;


        private void FixedUpdate()
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }

}
