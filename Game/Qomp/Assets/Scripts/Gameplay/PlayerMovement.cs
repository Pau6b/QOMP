using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {
        public class PlayerMovement : MonoBehaviour
        {
            public Vector3 m_direction;
            public float m_speed;
            Rigidbody m_tireRb;

            public delegate void OnDirectionChanged(Vector3 i_direction);
            public event OnDirectionChanged DirectionChanged;
            public event OnDirectionChanged DirectionChangedRequested;

            [SerializeField] private Transport m_TransportMovement;
            private bool m_fixDir = true;




            void Start()
            {
                m_TransportMovement.PlataformModeOn += PlatformMovementOn;
                m_TransportMovement.PlataformModeOff += PlatformMovementOff;
                m_tireRb = GetComponent<Rigidbody>();
                m_direction.Normalize();
                m_tireRb.velocity = m_speed * m_direction;
            }

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Space) && m_fixDir)
                {
                    Vector3 velocity = m_tireRb.velocity;
                    velocity.z = -velocity.z;
                    m_tireRb.velocity = velocity;
                    m_direction = m_tireRb.velocity.normalized;
                    DirectionChanged?.Invoke(m_direction);
                    DirectionChangedRequested?.Invoke(m_direction);
                }
            }

            void FixedUpdate()
            {
                if (m_fixDir)
                {
                    RenormalizeDirection();
                }
            }


            void RenormalizeDirection()
            {
                m_direction = m_tireRb.velocity.normalized;
                if (Mathf.Abs(m_tireRb.velocity.x) != Mathf.Abs(m_tireRb.velocity.z) && m_fixDir)
                {
                    if (m_direction.x > 0)
                    {
                        m_direction.x = 1;
                    }
                    else if (m_direction.x < 0)
                    {
                        m_direction.x = -1;
                    }
                    if (m_direction.z > 0)
                    {
                        m_direction.z = 1;
                    }
                    else if (m_direction.z < 0)
                    {
                        m_direction.z = -1;
                    }
                    m_direction.Normalize();
                    m_tireRb.velocity = m_speed * m_direction;
                }
            }


            private void OnCollisionEnter(Collision collision)
            {
                    DirectionChanged?.Invoke(m_direction);
            }

            private void PlatformMovementOn(Vector3 i_newDir)
            {
                m_direction = i_newDir;
                m_tireRb.velocity = m_speed * m_direction;
                GetComponent<Collider>().isTrigger = true;
                m_tireRb.useGravity = false;
                m_fixDir = false;
            }

            private void PlatformMovementOff()
            {
                float i = Mathf.Max(m_direction.x, Mathf.Max(m_direction.y, m_direction.z));
                if (i == 0.0)
                {
                    i = Mathf.Min(m_direction.x, Mathf.Min(m_direction.y, m_direction.z));
                }
                m_direction = new Vector3(i, 0, i);
                m_direction.Normalize();
                m_tireRb.velocity = m_speed * m_direction;
                GetComponent<Collider>().isTrigger = false;
                m_tireRb.useGravity = true;
                m_fixDir = true;
            }
        }
    }
}
