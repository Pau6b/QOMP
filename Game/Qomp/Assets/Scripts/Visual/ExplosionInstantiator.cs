using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    namespace Visual
    {
        public class ExplosionInstantiator : MonoBehaviour
        {
            [SerializeField] private GameObject m_explosionPrefab;
            [SerializeField] private GameObject m_particleContainer;

            // Start is called before the first frame update
            void Start()
            {
                Gameplay.RespawnComponent playerRespawnComponent = GetComponent<Gameplay.RespawnComponent>();
                playerRespawnComponent.Respawned += OnPlayerRespawned;
            }

            private void OnDestroy()
            {
                Gameplay.RespawnComponent playerRespawnComponent = GetComponent<Gameplay.RespawnComponent>();
                playerRespawnComponent.Respawned -= OnPlayerRespawned;
            }

            void OnPlayerRespawned(Vector3 i_oldPos)
            {
                FindObjectOfType<AudioManager>().PlaySound("Explosion");
                GameObject smoke = GameObject.Instantiate(m_explosionPrefab);
                smoke.transform.position = i_oldPos;
                smoke.transform.parent = m_particleContainer.transform;
                ParticleSystem smokeParticleSystem = smoke.GetComponent<ParticleSystem>();
                smokeParticleSystem.Play();
            }
        }
    }
}
