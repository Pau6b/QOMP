using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {
        public class SnakeBreakableDoor : MonoBehaviour
        {
            [SerializeField] private SnakeComponent m_snakeComponent;
            private Collider m_collider;

            void Start()
            {
                m_collider = GetComponent<Collider>();
                m_snakeComponent.SnakeStarted += OnSnakeStart;
                m_snakeComponent.SnakeEnded += OnSnakeEnd;
                m_collider.isTrigger = false;
            }

            private void OnDestroy()
            {
                m_snakeComponent.SnakeStarted -= OnSnakeStart;
                m_snakeComponent.SnakeEnded -= OnSnakeEnd;
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.tag == "Player")
                {
                    m_snakeComponent.OnDoorBroken();
                    GameObject.Destroy(transform.gameObject);
                }
            }

            void OnSnakeStart()
            {
                m_collider.isTrigger = true;
            }

            void OnSnakeEnd(SnakeEndReason i_endReason)
            {
                m_collider.isTrigger = false;
            }
        }

    }
}
