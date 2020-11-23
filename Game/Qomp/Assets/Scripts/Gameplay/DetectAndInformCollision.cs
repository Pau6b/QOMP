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
            public delegate void OnCollideInformed(Collision i_other);
            public event OnCollideInformed Collided;
            private void OnCollisionEnter(Collision i_other)
            {
                if (i_other.gameObject.tag == "Player")
                {
                    Collided?.Invoke(i_other);
                }
            }
        }
    }
}
