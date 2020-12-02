using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {
        public class RespawnComponent : MonoBehaviour
        {
            public delegate void OnPlayerRespawned();
            public event OnPlayerRespawned Respawned;

            [InspectorName("First Spawner")]
            public GameObject m_spawner;
            Vector3 m_velocity;
            Rigidbody m_rb;

            private void Start()
            {
                m_rb = GetComponent<Rigidbody>();
                m_velocity = m_rb.velocity;
                Vector3 newPosition = m_spawner.transform.position;
                newPosition.y = transform.position.y;
                transform.position = newPosition;
            }

            private void OnTriggerEnter(Collider i_other)
            {
                bool isSnakePartActive = i_other.gameObject.tag == "SnakePart" && i_other.GetComponent<SnakePartActivateComponent>().GetIsActive();
                if (i_other.gameObject.tag == "Spike" || isSnakePartActive)
                {
                    Vector3 newPosition = m_spawner.transform.position;
                    newPosition.y = transform.position.y;
                    transform.position = newPosition;
                    m_rb.velocity = m_velocity;
                    Respawned?.Invoke();
                }
                if (i_other.gameObject.tag == "RespawnPoint" && m_spawner != i_other.gameObject)
                {
                    m_spawner = i_other.gameObject;
                    m_velocity = m_rb.velocity;
                }
            }
        }
    }
}
