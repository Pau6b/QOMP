using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Visual
    {
        public class SparksInstantiator : MonoBehaviour
        {
            // Start is called before the first frame update
            [SerializeField] private GameObject m_sparkPrefab;
            [SerializeField] private GameObject m_particleContainer;

            void Start()
            {
                Gameplay.PlayerMovement playerMovement = GetComponent<Gameplay.PlayerMovement>();
                playerMovement.DirectionChanged += OnDirectionChanged;
            }
            private void OnDestroy()
            {
                Gameplay.PlayerMovement playerMovement = GetComponent<Gameplay.PlayerMovement>();
                playerMovement.DirectionChanged -= OnDirectionChanged;
            }

            void OnDirectionChanged(Gameplay.DirectionChangeReason i_changeReason, Vector3 i_direction, Collision i_collision)
            {
                if (i_changeReason == Gameplay.DirectionChangeReason.Collided)
                {
                    Quaternion rotation = Quaternion.LookRotation(i_collision.contacts[0].normal, new Vector3(0, 1, 0));
                    GameObject spark = GameObject.Instantiate(m_sparkPrefab);
                    spark.transform.position = i_collision.contacts[0].point;
                    spark.transform.rotation = rotation;
                    spark.transform.parent = m_particleContainer.transform;
                    ParticleSystem sparkParticleSystem = spark.GetComponent<ParticleSystem>();
                    sparkParticleSystem.Play();
                }
            }
        }
    }
}
