using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    namespace Gameplay
    {
        public class MoveSpike : MonoBehaviour
        {

            [SerializeField] private Vector3 m_direction;
            [SerializeField] private float m_speed;
            private Rigidbody m_rb;

            // Start is called before the first frame update
            void Start()
            {
                m_rb = GetComponent<Rigidbody>();
                m_rb.velocity = m_direction.normalized * m_speed;
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.transform.tag == "Wall")
                {
                    m_rb.velocity = -m_rb.velocity;
                }
            }
        }

    }
}
