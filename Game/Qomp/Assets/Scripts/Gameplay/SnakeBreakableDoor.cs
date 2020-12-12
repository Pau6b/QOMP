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

            void Start()
            {
                GetComponent<Collider>().isTrigger = false;
                m_snakeComponent.SnakeStarted += OnSnakeStart;
                m_snakeComponent.SnakeEnded += OnSnakeEnd;
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
                    GetComponent<Animator>().SetBool("isOpen", true);
                    Destroy(GetComponent<Collider>());
                }
            }

            void OnSnakeStart()
            {
                Collider collider = GetComponent<Collider>();
                if (collider != null)
                {
                    collider.isTrigger = true;
                }
            }

            void OnSnakeEnd(SnakeEndReason i_endReason)
            {
                Collider collider = GetComponent<Collider>();
                if (collider != null)
                {
                    collider.isTrigger = false;
                }
            }
        }

    }
}
