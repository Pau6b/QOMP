using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    namespace Gameplay
    {
        public class DetectAndInformCollision : MonoBehaviour
        {
            // Start is called before the first frame update
            public delegate void OnCollisionInformed(Collision i_other);
            public event OnCollisionInformed Collided;
            private void OnCollisionEnter(Collision i_other)
            {
               Collided?.Invoke(i_other);
            }
        }
    }
}
