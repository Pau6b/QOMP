using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    namespace Visual
    {
        public class SnakeParticlesInstantiator : MonoBehaviour
        {

            [SerializeField] private GameObject m_particle;
            [SerializeField] private GameObject m_particleContainer;
            [SerializeField, InspectorName("Spawn Frequency (Hz)")] private float m_spawnFrequency;
            private Gameplay.SnakeComponent m_snakeComponent;
            bool m_inSnake = false;
            float m_accumulatedTime = 0f;


            // Start is called before the first frame update
            void Start()
            {
                m_snakeComponent = GetComponent<Gameplay.SnakeComponent>();
                m_snakeComponent.SnakeStarted += OnSnakeStart;
                m_snakeComponent.SnakeEnded += OnSnakeEnd;
            }

            private void OnDestroy()
            {
                m_snakeComponent.SnakeStarted += OnSnakeStart;
                m_snakeComponent.SnakeEnded += OnSnakeEnd;
            }

            // Update is called once per frame
            void Update()
            {
                if (m_inSnake)
                {
                    m_accumulatedTime += Time.deltaTime;
                    if (m_spawnFrequency > 0)
                    {
                        float spawnTime = 1 / m_spawnFrequency;
                        if (m_accumulatedTime > spawnTime)
                        {
                            m_accumulatedTime -= spawnTime;
                            GameObject newParticleTrail = GameObject.Instantiate(m_particle);
                            newParticleTrail.transform.position = transform.position;
                            newParticleTrail.transform.parent = m_particleContainer.transform;
                        }
                    }
                }
            }
            void OnSnakeStart()
            {
                m_inSnake = true;
            }

            void OnSnakeEnd(Gameplay.SnakeEndReason i_endReason)
            {
                m_inSnake = false;
                if(i_endReason == Gameplay.SnakeEndReason.Died)
                {
                    for (int i = 0; i < m_particleContainer.transform.childCount; ++i)
                    {
                        GameObject.Destroy(m_particleContainer.transform.GetChild(i).gameObject);
                    }
                }
                if(i_endReason == Gameplay.SnakeEndReason.DoorBroken)
                {
                    for(int i = 0; i < m_particleContainer.transform.childCount; ++i)
                    {
                        ParticleSystem particleSystem = m_particleContainer.transform.GetChild(i).GetComponent<ParticleSystem>();
                        var mainComponent = particleSystem.main;
                        mainComponent.loop = false;
                    }
                }
            }
        }
    }
}
