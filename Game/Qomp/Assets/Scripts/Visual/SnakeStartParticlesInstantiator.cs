using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Visual
    {
        public class SnakeStartParticlesInstantiator : MonoBehaviour
        {
            // Start is called before the first frame update
            [SerializeField] private Gameplay.RespawnComponent m_respawnComponent;
            [SerializeField] private Gameplay.SnakeComponent m_snakeComponent;
            [SerializeField] private GameObject m_smokeRadiationPrefab;
            [SerializeField] private GameObject m_particleContainer;

            void Start()
            {
                m_respawnComponent.Respawned += OnPlayerRespawned;
                m_snakeComponent.SnakeStarted += OnSnakeStartEvent;
            }
            private void OnDestroy()
            {
                m_respawnComponent.Respawned -= OnPlayerRespawned;
                m_snakeComponent.SnakeStarted -= OnSnakeStartEvent;
            }

            void OnPlayerRespawned(Vector3 i_oldPosition)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }

            void OnSnakeStartEvent()
            {
                GetComponent<MeshRenderer>().enabled = false;
                GameObject smoke = GameObject.Instantiate(m_smokeRadiationPrefab);
                smoke.transform.position = transform.position;
                smoke.transform.parent = m_particleContainer.transform;
                ParticleSystem smokeParticleSystem = smoke.GetComponent<ParticleSystem>();
                smokeParticleSystem.Play();
            }
        }
    }
}
