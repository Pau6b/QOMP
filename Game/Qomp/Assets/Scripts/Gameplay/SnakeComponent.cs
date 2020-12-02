using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Gameplay
    {
        public class SnakeComponent : MonoBehaviour
        {
            // Start is called before the first frame update
            [SerializeField] private GameObject m_snakePart;
            [SerializeField] private GameObject m_snakePartsContainer;
            private bool m_inSnake;
            private Vector3 m_previousDirectionChangePoint;

            void Start()
            {
                PlayerMovement playerMovementComponent = GetComponent<PlayerMovement>();
                playerMovementComponent.DirectionChanged += OnDirectionChanged;
                RespawnComponent playerRespawnComponent = GetComponent<RespawnComponent>();
                playerRespawnComponent.Respawned += OnPlayerRespawned;

            }

            // Update is called once per frame
            void Update()
            {
        
            }
            private void OnDestroy()
            {
                PlayerMovement playerMovementComponent = GetComponent<PlayerMovement>();
                playerMovementComponent.DirectionChanged -= OnDirectionChanged;
                RespawnComponent playerRespawnComponent = GetComponent<RespawnComponent>();
                playerRespawnComponent.Respawned -= OnPlayerRespawned;
            }

            void OnDirectionChanged(Vector3 i_direction)
            {
                if (m_inSnake)
                {
                    Vector3 newPoint = transform.position;
                    Vector3 middlePoint = (newPoint + m_previousDirectionChangePoint) / 2;
                    GameObject snakePart = GameObject.Instantiate(m_snakePart);
                    snakePart.transform.SetParent(m_snakePartsContainer.transform);
                    snakePart.transform.position = middlePoint;
                    snakePart.transform.rotation = Quaternion.LookRotation(new Vector3(1,0,1), new Vector3(0,1,0));
                    Vector3 movedDirectionVector = newPoint - m_previousDirectionChangePoint;
                    Vector3 upRightVector = new Vector3(1, 0, 1).normalized;
                    Vector3 downRightVector = new Vector3(1, 0, -1).normalized;
                    float upRightLength = Mathf.Abs(Vector3.Dot(movedDirectionVector, upRightVector));
                    float downRightLength = Mathf.Abs(Vector3.Dot(movedDirectionVector, downRightVector));
                    snakePart.GetComponent<BoxCollider>().size = new Vector3(Mathf.Max(downRightLength, 1.5f), 1, Mathf.Max(upRightLength, 1.5f));

                    m_previousDirectionChangePoint = newPoint;
                }
            }
            void OnTriggerEnter(Collider i_other)
            {
                 if (i_other.gameObject.tag == "SnakeEvolvePoint")
                {
                    m_inSnake = true;
                    m_previousDirectionChangePoint = transform.position;
                }
            }
             
            void OnPlayerRespawned()
            {
                m_inSnake = false;
                for (int i = 0; i < m_snakePartsContainer.transform.childCount; ++i)
                {
                    GameObject.Destroy(m_snakePartsContainer.transform.GetChild(i).gameObject);
                }
            }
        }

    }
}
