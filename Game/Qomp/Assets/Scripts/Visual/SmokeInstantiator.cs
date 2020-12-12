using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Visual
    {
        public class SmokeInstantiator : MonoBehaviour
        {
            [SerializeField] private GameObject m_smokePrefab;
            [SerializeField] private GameObject m_particleContainer;
            [SerializeField] private float m_distanceToInstantiate = 0;

            // Start is called before the first frame update
            void Start()
            {
                Gameplay.PlayerMovement playerMovement = GetComponent<Gameplay.PlayerMovement>();
                playerMovement.DirectionChanged += OnDirectionChanged;
            }

            private void OnDestroy()
            {
                Gameplay.PlayerMovement playerMovement = GetComponent<Gameplay.PlayerMovement>();
               playerMovement.DirectionChanged-= OnDirectionChanged;
            }

            void OnDirectionChanged(Gameplay.DirectionChangeReason i_reason, Vector3 i_direction, Collision i_collision)
            {
                if (i_reason == Gameplay.DirectionChangeReason.Requested)
                {
                    Vector3 position = transform.position - i_direction * m_distanceToInstantiate ;
                    GameObject smoke = GameObject.Instantiate(m_smokePrefab);
                    smoke.transform.position = position;
                    smoke.transform.parent = m_particleContainer.transform;
                    ParticleSystem smokeParticleSystem = smoke.GetComponent<ParticleSystem>();
                    smokeParticleSystem.Play();
                }
            }
        }
    }
}
